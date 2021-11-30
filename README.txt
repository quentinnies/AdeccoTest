I had a lot trouble with my threads and JSON serialization, partly because the default serializer does not show private arguments of a class and I forgot about that.
My threads were interloping and I had a lot of corrupted data
I created a lot of classes to nest details but I was a bit optimistic about the time this morning

To improve:
- actually having a dynamic table in the frontend, I'm not familiar enought yet with React to do it within the day
- A custom serializer for the data sent to the front end
- Fetching and using more detailed data (types and stats for example)
- Actually implementing tests 
- improve the Pokemon details serialization, I'm not a fan of casting data in general