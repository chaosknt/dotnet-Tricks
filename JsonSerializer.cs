/// <summary>
        /// Determines whether a property's name uses a case-insensitive comparison during deserialization.
        /// The default value is false.
        /// </summary>
        /// <remarks>There is a performance cost associated when the value is true.</remarks>
var contentResponseDeserialized = JsonSerializer.Deserialize<PlantaOperacionDto>(contentResponseAsString,
                new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
