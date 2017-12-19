# Scalable-order-post-processing-system

1. We should have indexing on primary keys to search faster.
2. We can have sharding in Database based on a Hash function of primary key of that table.
3. For adding/removing a shard we can use consistent hashing.
4. Consistent hashing is a special kind of hashing such that when a hash table is resized, only K/n keys need to be remapped on average, where K is the number of keys, and n is the number of slots. Consistent hashing is based on mapping each object to a point on a ring, each point belongs to the nearest node on the ring (Clockwise/Anticlockwise).
