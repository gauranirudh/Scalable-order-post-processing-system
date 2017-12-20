# Scalable-order-post-processing-system

1. We should have indexing on primary keys to search faster.
2. We can have sharding in Database based on a Hash function of primary key of that table.
3. For adding/removing a shard we can use consistent hashing.
4. Consistent hashing is a special kind of hashing such that when a hash table is resized, only K/n keys need to be remapped on average, where K is the number of keys, and n is the number of slots. Consistent hashing is based on mapping each object to a point on a ring, each point belongs to the nearest node on the ring (Clockwise/Anticlockwise).
5. I have used RabbitMQ to receive a message when an order is processed successfully or invoice is generated successfully to start sending sms/emails to the user.
6. Please go through the Database schema file(.dbs extension) for Database design.
7. We can Master Slave for data replication and avoid single point of failure if a Database server goes down.
8. To implement Master-Slave, have a master node in each shard which has a slave node which reads all new updates from master and keeps updating itself. Clients can read from either the master or the slave depending on which responds earlier.

System Limits:
1. Lets assume that we have to process 10M QPS(queries/Orders per second) or 166667 queries/orders per min.
2. Lets assume that we would have to store is 30TB data. We can accommodate 72GB of data on every single machine ( neglected process memory overheads for the time being ). With that, we would need 420 machines. With that config, every machine would handle around 23000 QPS(queries per second).
3. Next assuming that a machine has to serve 23,000 QPS then we look at each machine has 4 core and then we calculate the per request time as - CPU time available per query = 4 * 1000 * 1000 / 23000 microseconds = 174us (Note everything is converted to milliseconds.) So the machines have to return the query in 174 us.
4. Sending SMS/Email will take extra time than above depending on time taken by RabbitMQ and third party services. Although messages flow through RabbitMQ and our applications, they can only be stored inside a queue. A queue is only bound by the host's memory & disk limits.
