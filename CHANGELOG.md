# Changelog

## [2.0.0] - 23-01-2024

### Unity.Runtime

### Added

#### GameObject Extensions

##### Prefab
- `IsPrefab(this GameObject gameObject)`: Checks if the GameObject is a prefab.

##### HasComponent
- `HasComponent<T>(this GameObject gameObject)`: Checks if the GameObject has a specified component type.
- `HasRigidbody(this GameObject gameObject)`: Checks if the GameObject has a Rigidbody component.
- `HasAnimation(this GameObject gameObject)`: Checks if the GameObject has an Animation component.
- `HasAnimator(this GameObject gameObject)`: Checks if the GameObject has an Animator component.

##### Component
- `TryGetComponent<T>(this GameObject gameObject, out T outComponent)`: Attempts to get a component of type T from the GameObject.
- `TryGetComponentInParent<T>(this GameObject gameObject, out T outComponent)`: Attempts to get a component of type T from the GameObject or its ancestors.
- `TryGetComponentInChildren<T>(this GameObject gameObject, out T outComponent)`: Attempts to get a component of type T from the GameObject or its descendants.
- `GetOrAddComponent<T>(this GameObject gameObject)`: Gets or adds a component of type T to the GameObject.
- `GetOrAddComponent(this GameObject gameObject, Type type)`: Gets or adds a component of the specified type to the GameObject.
- `DestroyComponent<T>(this GameObject gameObject)`: Destroys a component of type T on the GameObject.
- `DestroyComponent(this GameObject gameObject, Type type)`: Destroys a component of the specified type on the GameObject.
- `SearchComponent<T>(this GameObject gameObject, string searchName)`: Searches for a component of type T with the specified name in the GameObject's descendants.
- `FindComponentInParents<T>(this GameObject gameObject)`: Finds a component of type T in the GameObject's ancestors.
- `FindComponentInParents(this GameObject gameObject, Type type)`: Finds a component of the specified type in the GameObject's ancestors.

##### Path
- `CreateChild(this GameObject gameObject, string pathName, char splitChar = '/')`: Creates child GameObjects based on the provided path name.
- `Path(this GameObject gameObject)`: Gets the path of the GameObject in the scene hierarchy.
- `PathFull(this GameObject gameObject)`: Gets the full path of the GameObject in the scene hierarchy, including the GameObject's name.
- `Root(this GameObject go)`: Gets the root GameObject in the hierarchy of the provided GameObject.
- `Depth(this GameObject go)`: Gets the depth of the GameObject in the hierarchy.

##### Layer
- `ContainLayer(this GameObject gameObject, int otherLayerIndex)`: Checks if the GameObject's layer is included in a specific layer index.
- `ContainLayer(this GameObject gameObject, LayerMask otherLayerMask)`: Checks if the GameObject's layer is included in a specific LayerMask.
- `ContainLayers(this GameObject gameObject, params LayerMask[] otherLayerMasks)`: Checks if the GameObject's layer is included in all specified LayerMasks.
- `ContainOneOfLayers(this GameObject gameObject, params LayerMask[] otherLayerMasks)`: Checks if the GameObject's layer is included in at least one of the specified LayerMasks.
- `SetLayer(this GameObject gameObject, LayerMask layerMask)`: Sets the layer of the GameObject using the provided LayerMask.
- `SetLayerRecursion(this GameObject gameObject, LayerMask layerMask)`: Sets the layer of the GameObject and its children using the provided LayerMask.
- `SetLayerRecursion(this GameObject gameObject, int layerIndex)`: Sets the layer of the GameObject and its children using the provided layer index.

##### Tag
- `SetTag(this GameObject gameObject, string tag)`: Sets the tag of the GameObject.
- `SetTagRecursion(this GameObject gameObject, string tag)`: Sets the tag of the GameObject and its children.

##### Particle
- `GetParticleDuration(this GameObject gameObject, bool includeChildren = true, bool includeInactive = false, bool allowLoop = false)`: Gets the duration of the ParticleSystem on the GameObject.

##### Trail Renderer
- `GetTrailRendererTime(this GameObject gameObject)`: Gets the maximum time of TrailRenderer(s) on the GameObject.

##### Bounds
- `GetBounds(this GameObject gameObject, bool includeChildren = true)`: Gets the bounding box of the GameObject.

#### MeshFilter Extensions

- `GetBounds(this MeshFilter meshFilter, bool includeChildren = true)`: Gets the bounds of the mesh filter.

#### ParticleSystemExtensions

- `GetDuration(this ParticleSystem particle, bool allowLoop = false)`: Retrieves the duration. Returns -1 if `allowLoop` is false and the system is looping.
- `GetMaxValue(this ParticleSystem.MinMaxCurve minMaxCurve)`: Obtains the maximum value.
- `GetMinValue(this ParticleSystem.MinMaxCurve minMaxCurve)`: Gets the minimum value.

#### Renderer Extensions

##### Visibility
- `IsVisible(this Renderer renderer, Camera camera)`: Checks if the renderer is visible from the specified camera.

##### Bounds
- `GetBounds(this Renderer renderer, bool includeChildren = true)`: Gets the bounds of the renderer. If `includeChildren` is true, the bounds encapsulate the bounds of child renderers.

##### Material
- `GetMaterial(this Renderer renderer, int materialIndex)`: Gets the material at the specified index. Returns null if the index is out of range.

#### LayerMask Extensions

##### Containment
- `Contains(this LayerMask layerMask, LayerMask otherLayerMask)`: Checks if the layer mask contains the other layer mask.
- `Contains(this LayerMask layerMask, int layerIndex)`: Checks if the layer mask contains the specified layer index.

##### Information Retrieval
- `GetLayerIndex(this LayerMask layerMask)`: Gets the layer index of the layer mask. Returns -1 if an error occurred.
- `Inverse(this LayerMask layerMask)`: Inverts the layer mask.

##### Modification
- `AddToMask(this LayerMask layerMask, params string[] name)`: Adds the specified layers to the layer mask.
- `RemoveFromMask(this LayerMask layerMask, params string[] name)`: Removes the specified layers from the layer mask.

##### Conversion
- `MaskToNames(this LayerMask layerMask)`: Converts the layer mask to an array of layer names.
- `MaskToString(this LayerMask layerMask)`: Converts the layer mask to a string.
- `MaskToString(this LayerMask layerMask, string delimiter)`: Converts the layer mask to a string with the specified delimiter.
- `internal static LayerMask NameToMask(params string[] layerNames)`: Converts the specified layer names to a layer mask.

#### AnimationCurve Extensions

##### Looping
- `IsLooping(this AnimationCurve animationCurve)`: Checks if the animation curve is looping.

##### Value Retrieval
- `GetMaxValue(this AnimationCurve animationCurve)`: Gets the maximum value of the animation curve.
- `GetMinValue(this AnimationCurve animationCurve)`: Gets the minimum value of the animation curve.

##### Modification
- `Reverse(this AnimationCurve animationCurve)`: Reverses the animation curve.

## [1.3.0] - 23-01-2024

### Added

#### StringExtensions

- `IsMatch` method to check if a string matches the given pattern.
- `IsMatch` method to check if a string matches the given Regex.
- `Match` method to return the first match of the pattern in the string.
- `Match` method to return the first match of the Regex in the string.
- `Matches` method to return all matches of the pattern in the string.
- `Matches` method to return all matches of the pattern in the string with the specified options.
- `MatchValues` method to return all match values of the pattern in the string.
- `MatchValues` method to return all match values of the pattern in the string with the specified options.

#### GenericExtensions

##### Null / Empty

- `IsNull` method to check if the value is null.
- `IsNotNull` method to check if the value is not null.
- `IsEmpty` method to check if the value is the default value for its type.
- `IsNotEmpty` method to check if the value is not the default value for its type.
- `ToNullable` method to convert the value to a nullable type.

##### Equal

- `EqualsAny` method to check if the value is equal to any of the provided values.
- `EqualsNone` method to check if the value is not equal to any of the provided values.

##### Flag

- `HasFlags` method to check if the value has all the specified flags.

#### ObjectExtensions

##### Null

- `IsNull` method to check if the object is null.
- `IsNotNull` method to check if the object is not null.

##### Type

- `CastType<T>` method to cast the object to the specified type.
- `CastType` method to cast the object to the specified type.
- `ConvertTo<T>` method to convert the object to the specified type.
- `CanConvertTo<T>` method to check if the object can be converted to the specified type.

##### As

- `AsString` method to convert the object to a string.
- `AsString` method to convert the object to a string using the specified format provider.
- `AsInvariantString` method to convert the object to a string using the invariant culture.
- `AsInt` method to convert the object to an integer.
- `AsLong` method to convert the object to a long.
- `AsShort` method to convert the object to a short.
- `AsFloat` method to convert the object to a float.
- `AsDouble` method to convert the object to a double.
- `AsDecimal` method to convert the object to a decimal.

#### TaskAwaiterExtensions

- `GetAwaiter(this TimeSpan timeSpan)` method to get a `TaskAwaiter` that completes after a specified time period.
- `GetAwaiter(this int seconds)` method to get a `TaskAwaiter` that completes after a specified number of seconds.
- `GetAwaiter(this float seconds)` method to get a `TaskAwaiter` that completes after a specified number of seconds.

#### IList Extensions

- `Random<T>(this IList<T> list)` method to get a random item from the list.
- `Random<T>(this IList<T> list, Predicate<T> predicate)` method to get a random item from the list that matches a predicate.
- `Random<T>(this IList<T> list, int count, bool allowRepeat = false)` method to get a specified number of random items from the list.
- `Random<T>(this IList<T> list, Func<T, int> weightGetter)` method to get a random item from the list, with the probability of choosing each item proportional to its weight.
- `Random<T>(this IList<T> list, Func<T, int> weightGetter, int count)` method to get a specified number of random items from the list, with the probability of choosing each item proportional to its weight.
- `Random<T>(this IList<T> list, Func<T, float> weightGetter)` method to get a random item from the list, with the probability of choosing each item proportional to its weight.
- `Random<T>(this IList<T> list, Func<T, float> weightGetter, int count)` method to get a specified number of random items from the list, with the probability of choosing each item proportional to its weight.

## [1.2.0] - 23-01-2024

### Added

#### ArrayExtensions

- `Sort` method to sort the elements in the entire array using the specified comparison.
- `Sort` method to sort a range of elements in the array using the specified comparer.
- `RandSort` method to sort the elements in the array in random order.

## [1.1.0] - 22-01-2024

### Added

#### BoolExtensions

- `And` extension method:
  - Overloads:
    - `And(this bool boolean, Func<bool> other)`: Performs a logical AND operation on the first boolean value and a function returning a boolean.
    - `And<T>(this bool boolean, Func<T, bool> other, T value)`: Performs a logical AND operation on the first boolean value and a function taking one parameter and returning a boolean.
    - `And<T1, T2>(this bool boolean, Func<T1, T2, bool> other, T1 value1, T2 value2)`: Performs a logical AND operation on the first boolean value and functions taking two parameters and returning a boolean.
    - `And<T1, T2, T3>(this bool boolean, Func<T1, T2, T3, bool> other, T1 value1, T2 value2, T3 value3)`: Performs a logical AND operation on the first boolean value and functions taking three parameters and returning a boolean.
    - `And<T1, T2, T3, T4>(this bool boolean, Func<T1, T2, T3, T4, bool> other, T1 value1, T2 value2, T3 value3, T4 value4)`: Performs a logical AND operation on the first boolean value and functions taking four parameters and returning a boolean.
    - `And<T1, T2, T3, T4, T5>(this bool boolean, Func<T1, T2, T3, T4, T5, bool> other, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)`: Performs a logical AND operation on the first boolean value and functions taking five parameters and returning a boolean.

- `AndNot` extension method:
  - Overloads:
    - `AndNot(this bool boolean, Func<bool> other)`: Performs a logical AND NOT operation on the first boolean value and a function returning a boolean.
    - `AndNot<T>(this bool boolean, Func<T, bool> other, T value)`: Performs a logical AND NOT operation on the first boolean value and a function taking one parameter and returning a boolean.
    - `AndNot<T1, T2>(this bool boolean, Func<T1, T2, bool> other, T1 value1, T2 value2)`: Performs a logical AND NOT operation on the first boolean value and functions taking two parameters and returning a boolean.
    - `AndNot<T1, T2, T3>(this bool boolean, Func<T1, T2, T3, bool> other, T1 value1, T2 value2, T3 value3)`: Performs a logical AND NOT operation on the first boolean value and functions taking three parameters and returning a boolean.
    - `AndNot<T1, T2, T3, T4>(this bool boolean, Func<T1, T2, T3, T4, bool> other, T1 value1, T2 value2, T3 value3, T4 value4)`: Performs a logical AND NOT operation on the first boolean value and functions taking four parameters and returning a boolean.
    - `AndNot<T1, T2, T3, T4, T5>(this bool boolean, Func<T1, T2, T3, T4, T5, bool> other, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)`: Performs a logical AND NOT operation on the first boolean value and functions taking five parameters and returning a boolean.

- `Or` extension method:
  - Overloads:
    - `Or(this bool boolean, Func<bool> other)`: Performs a logical OR operation on the first boolean value and a function returning a boolean.
    - `Or<T>(this bool boolean, Func<T, bool> other, T value)`: Performs a logical OR operation on the first boolean value and a function taking one parameter and returning a boolean.
    - `Or<T1, T2>(this bool boolean, Func<T1, T2, bool> other, T1 value1, T2 value2)`: Performs a logical OR operation on the first boolean value and functions taking two parameters and returning a boolean.
    - `Or<T1, T2, T3>(this bool boolean, Func<T1, T2, T3, bool> other, T1 value1, T2 value2, T3 value3)`: Performs a logical OR operation on the first boolean value and functions taking three parameters and returning a boolean.
    - `Or<T1, T2, T3, T4>(this bool boolean, Func<T1, T2, T3, T4, bool> other, T1 value1, T2 value2, T3 value3, T4 value4)`: Performs a logical OR operation on the first boolean value and functions taking four parameters and returning a boolean.
    - `Or<T1, T2, T3, T4, T5>(this bool boolean, Func<T1, T2, T3, T4, T5, bool> other, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)`: Performs a logical OR operation on the first boolean value and functions taking five parameters and returning a boolean.

- `OrNot` extension method:
  - Overloads:
    - `OrNot(this bool boolean, Func<bool> other)`: Performs a logical OR NOT operation on the first boolean value and a function returning a boolean.
    - `OrNot<T>(this bool boolean, Func<T, bool> other, T value)`: Performs a logical OR NOT operation on the first boolean value and a function taking one parameter and returning a boolean.
    - `OrNot<T1, T2>(this bool boolean, Func<T1, T2, bool> other, T1 value1, T2 value2)`: Performs a logical OR NOT operation on the first boolean value and functions taking two parameters and returning a boolean.
    - `OrNot<T1, T2, T3>(this bool boolean, Func<T1, T2, T3, bool> other, T1 value1, T2 value2, T3 value3)`: Performs a logical OR NOT operation on the first boolean value and functions taking three parameters and returning a boolean.
    - `OrNot<T1, T2, T3, T4>(this bool boolean, Func<T1, T2, T3, T4, bool> other, T1 value1, T2 value2, T3 value3, T4 value4)`: Performs a logical OR NOT operation on the first boolean value and functions taking four parameters and returning a boolean.
    - `OrNot<T1, T2, T3, T4, T5>(this bool boolean, Func<T1, T2, T3, T4, T5, bool> other, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)`: Performs a logical OR NOT operation on the first boolean value and functions taking five parameters and returning a boolean.

## [1.0.0] - 21-01-2024

### Added

#### ArrayExtensions

- `IsNullOrEmpty` extension method to check if an array is null or empty.
- `IsEmpty` extension method to check if an array is empty.
- `WithinIndex` extension methods to check if an index is within the bounds of the array or a specific dimension.
- `Swap` extension method to swap elements at specified indices in the array.
- `Find` extension methods to find elements in the array based on a given predicate.
- `IndexOf` extension method to find the index of a specified object in a one-dimensional array.
- `CombineArray` extension method to combine two arrays into one.
- `ClearAt` extension methods to clear the value at a specified index in the array.
- `ClearAll` extension methods to clear all values in the array.
- `BlockCopy` extension methods to copy elements from a source array to a new array, either of a specified length or padded to the length.
- `AsObjects` extension method to convert an array of a specific type to an array of objects.
- `First` extension method to get the first element of an array, or a default value if the array contains no elements.
- `First` extension method to get the first element of an array that satisfies a specified condition, or a default value if no such element is found.
- `Last` extension method to get the last element of an array, or a default value if the array contains no elements.
- `Last` extension method to get the last element of an array that satisfies a specified condition, or a default value if no such element is found.
- `Contains` extension method to determine whether an array contains a specific value.
- `Contains` extension method to determine whether an array contains elements that satisfy a specified condition.

#### ArrayListExtensions

- `IsNullOrEmpty` extension method to check if an ArrayList is null or empty.
- `IsEmpty` extension method to check if an ArrayList is empty.
- `First` and `Last` extension methods to retrieve the first and last elements of the ArrayList.

#### BoolExtensions

- `And` extension method to perform a logical AND operation on two boolean values.
- `Or` extension method to perform a logical OR operation on two boolean values.
- `AndNot` extension method to perform a logical AND operation on the first boolean value and the logical NOT of the second boolean value.
- `OrNot` extension method to perform a logical OR operation on the first boolean value and the logical NOT of the second boolean value.
- `Xor` extension method to perform a logical XOR operation on two boolean values.

#### ByteExtensions

- `IsEven` extension method to check if a byte value is even.
- `IsOdd` extension method to check if a byte value is odd.
- `ToInt` extension method to convert a byte array to an integer.
- `ToLong` extension method to convert a byte array to a long.
- `ToChar` extension method to convert a byte array to a char.
- `ToFloat` extension method to convert a byte array to a float.
- `ToDouble` extension method to convert a byte array to a double.
- `ToBoolean` extension method to convert a byte array to a boolean.
- `ToString` extension method to convert a byte array to a string.
- `ToType<T>` extension method to convert a byte array to a specified type using binary deserialization.

#### CharExtensions

- `IsControl` extension method to check if a character is a control character.
- `IsDigit` extension method to check if a character is a digit.
- `IsHighSurrogate` extension method to check if a character is a high surrogate.
- `IsLowSurrogate` extension method to check if a character is a low surrogate.
- `IsPunctuation` extension method to check if a character is a punctuation symbol.
- `IsLetter` extension method to check if a character is a letter.
- `IsLetterOrDigit` extension method to check if a character is a letter or a digit.
- `IsSymbol` extension method to check if a character is a symbol.
- `IsSeparator` extension method to check if a character is a separator.
- `IsSurrogate` extension method to check if a character is a surrogate.
- `IsLower` extension method to check if a character is a lowercase letter.
- `IsUpper` extension method to check if a character is an uppercase letter.
- `ToLower` extension method to convert a character to lowercase.
- `ToUpper` extension method to convert a character to uppercase.
- `IsWhiteSpace` extension method to check if a character is white space.

#### DecimalExtensions

- `Abs` extension method to calculate the absolute value of a decimal.
- `Abs` extension method to calculate the absolute values for each element in an enumerable collection of decimals.
- `RoundDecimalPoints` extension method to round a decimal value to a specified number of decimal points.
- `RoundToTwoDecimalPoints` extension method to round a decimal value to two decimal points.

#### DoubleExtensions

- `Abs` extension method to calculate the absolute value of a double.
- `Abs` extension method to calculate the absolute values for each element in an enumerable collection of doubles.
- `RoundDecimalPoints` extension method to round a double value to a specified number of decimal points.
- `RoundToTwoDecimalPoints` extension method to round a double value to two decimal points.
- `IsInRange` extension method to determine whether a double value is within a specified range.
- `InRange` extension method to return a double value if it is within a specified range; otherwise, returns a default value.
- `ToDays` extension method to convert a double value to a TimeSpan representing days.
- `ToHours` extension method to convert a double value to a TimeSpan representing hours.
- `ToMinutes` extension method to convert a double value to a TimeSpan representing minutes.
- `ToSeconds` extension method to convert a double value to a TimeSpan representing seconds.
- `ToMilliseconds` extension method to convert a double value to a TimeSpan representing milliseconds.

#### EnumExtensions

- `ClearFlag` method to clear a specific flag from an enumeration value.
- `ClearFlags` method to clear multiple flags from an enumeration value.
- `SetFlag` method to set a specific flag in an enumeration value.
- `SetFlags` method to set multiple flags in an enumeration value.
- `ContainsFlag` method to check if an enumeration value contains a specific flag.
- `FromString` method to convert a string to an enumeration value.
- `TryParse` method to try converting a string to an enumeration value.
- `EnumIndex` method to get the index of a specific integer value in an enumeration.
- `EnumIndex` method to get the index of a specific byte value in an enumeration.

#### FloatExtensions

- `Abs` method to calculate the absolute value of a float.
- `Abs` method to calculate the absolute values for each element in an enumerable collection of floats.
- `ClampMin0` method to clamp a float value to a minimum of 0.
- `ClampMin` method to clamp a float value to a specified minimum.
- `ClampMax0` method to clamp a float value to a maximum of 0.
- `ClampMax` method to clamp a float value to a specified maximum.
- `Clamp01` method to clamp a float value between 0 and 1.
- `Clamp` method to clamp a float value to a specified range.
- `RoundDecimalPoints` method to round a float value to a specified number of decimal points.
- `RoundToTwoDecimalPoints` method to round a float value to two decimal points.
- `IsInRange` method to determine whether a float value is within a specified range.
- `InRange` method to return a float value if it is within a specified range; otherwise, returns a default value.
- `ToDays` method to convert a float value to a TimeSpan representing days.
- `ToHours` method to convert a float value to a TimeSpan representing hours.
- `ToMinutes` method to convert a float value to a TimeSpan representing minutes.
- `ToSeconds` method to convert a float value to a TimeSpan representing seconds.
- `ToMilliseconds` method to convert a float value to a TimeSpan representing milliseconds.

#### HashSetExtensions

- `AddRange` extension method to add a range of elements to the end of the HashSet.

#### ICollectionExtensions

- `IsNullOrEmpty` extension methods to check if a collection is null or empty.
- `IsEmpty` extension methods to check if a collection is empty.
- `AddUnique` extension method to add a unique item to the collection. If the item already exists, it will not be added.
- `AddRangeUnique` extension method to add a range of unique items to the collection. If an item already exists, it will not be added.

#### IDictionaryExtensions

- `IsNullOrEmpty` extension methods to check if a dictionary is null or empty.
- `IsEmpty` extension methods to check if a dictionary is empty.
- `Add` extension methods to add items to the dictionary, with options to replace existing items.
- `AddRange` extension methods to add a range of items to the dictionary, with options to replace existing items.
- `Merge` extension method to merge multiple dictionaries into one.
- `GetValue` and `GetOrAdd` extension methods to retrieve values from the dictionary, with options to provide default values.
- `RemoveValue` extension methods to remove items from the dictionary based on their values.

#### IEnumerableExtensions

- `IsNullOrEmpty`, `IsEmpty`, and `IsNotEmpty` extension methods to check if an IEnumerable is null, empty, or not empty.
- `Has` extension method to find the first element that matches the conditions defined by the specified predicate.
- `Find` extension method to search for the first element that matches the conditions defined by the specified predicate.
- `FindAll` extension method to retrieve all elements that match the conditions defined by the specified predicate.
- `Except` extension method to produce the set difference of two sequences.
- `Without` extension method to filter elements based on a predicate that identifies the item to be excluded.
- `ToDictionary` extension method to convert a sequence of value tuples to a Dictionary.
- `IsEquivalentTo` extension method to determine whether two sequences are equivalent by comparing their elements using the default equality comparer.
- `ToHashSet` extension method to convert an IEnumerable to a HashSet.
- `Any` extension method to determine whether a sequence contains any elements.
- `Any` extension method to determine whether any element of a sequence satisfies a condition.
- `First` extension method to return the first element of a sequence or a default value if the sequence is empty.
- `First` extension method to return a specified number of contiguous elements from the start of a sequence.
- `Last` extension method to return the last element of a sequence or a default value if the sequence is empty.
- `Last` extension method to return a specified number of contiguous elements from the end of a sequence.
- `ToArray` extension method to create an array from an `IEnumerable<T>`.
- `ToList` extension method to create a `List<T>` from an `IEnumerable<T>`.

#### IListExtensions

- `IsNullOrEmpty` and `IsEmpty` extension methods to check if an IList is null, empty, or not empty.
- `Swap` extension method to swap elements at specified indices in the list.
- `AddUnique` extension method to add an item to the list if it is not already present.
- `InsertUnique` extension method to insert an item into the list at the specified index, if it is not already present.
- `InsertRangeUnique` extension method to insert a range of items into the list at the specified index, skipping any items that are already present.
- `TryGetValue` extension method to try to get a value from the list.
- `GetAndRemove` extension methods to get and remove a value from the list, either by value or by index.
- `Before` and `After` extension methods to get the item before or after a specified item in the list.
- `Find` and `FindAll` extension methods to find the first item or all items that match the specified predicate.
- `MoveUp` and `MoveDown` extension methods to move an item up or down in the list by a specified number of steps.
- `RemoveStartRepeat`, `RemoveEndRepeat`, and `Distinct` extension methods to remove repeated items from the start, end, or throughout the list.
- `First` extension method to get the first element of a list that satisfies a specified condition, or a default value if no such element is found.
- `First` extension method to get a specified number of contiguous elements from the start of a list, optionally filtering the elements with a predicate.
- `Last` extension method to get the last element of a list that satisfies a specified condition, or a default value if no such element is found.
- `Last` extension method to get a specified number of contiguous elements from the end of a list, optionally filtering the elements with a predicate.
- `Contains` extension method to determine whether a list contains elements that satisfy a specified condition.

#### IntExtensions

- `ClampMin0` method to clamp an integer value to a minimum of 0.
- `ClampMin` method to clamp an integer value to a specified minimum.
- `ClampMax0` method to clamp an integer value to a maximum of 0.
- `ClampMax` method to clamp an integer value to a specified maximum.
- `Clamp01` method to clamp an integer value between 0 and 1.
- `Clamp` method to clamp an integer value to a specified range.
- `Abs` method to calculate the absolute value of an integer.
- `Abs` method to calculate the absolute values for each element in an enumerable collection of integers.
- `IsInRange` method to determine whether an integer value is within a specified range.
- `InRange` method to return an integer value if it is within a specified range; otherwise, returns a default value.
- `IsEven` method to check if an integer value is even.
- `IsOdd` method to check if an integer value is odd.
- `GetArrayIndex` method to return the array index corresponding to an integer value.
- `IsIndexInArray` method to determine whether an integer value is a valid index in a specified array.

#### ListExtensions

- `RemoveDuplicates` extension method to remove duplicate elements from a list.

#### LongExtensions

- `Abs` method to calculate the absolute value of a long.
- `Abs` method to calculate the absolute values for each element in an enumerable collection of longs.
- `IsInRange` method to determine whether a long value is within a specified range.
- `InRange` method to return a long value if it is within a specified range; otherwise, returns a default value.
- `IsEven` method to check if a long value is even.
- `IsOdd` method to check if a long value is odd.

#### ShortExtensions

- `Abs` method to calculate the absolute value of a short.
- `Abs` method to calculate the absolute values for each element in an enumerable collection of shorts.
- `IsInRange` method to determine whether a short value is within a specified range.
- `InRange` method to return a short value if it is within a specified range; otherwise, returns a default value.
- `IsEven` method to check if a short value is even.
- `IsOdd` method to check if a short value is odd.

#### StringExtensions

- `IsNullOrEmpty` extension method to check if the string is null or empty.
- `IsNotNullOrEmpty` extension method to check if the string is not null or empty.
- `IsEmptyOrWhiteSpace` extension method to check if the string is empty or contains only white-space characters.
- `IsNotEmptyOrWhiteSpace` extension method to check if the string is not empty and does not contain only white-space characters.
- `IfEmptyOrWhiteSpace` extension method to return the string or a default value based on its emptiness or white-space content.
- Conversion methods to various types: `IsBoolean`, `AsBoolean`, `IsShort`, `AsShort`, `IsInt`, `AsInt`, `IsLong`, `AsLong`, `IsFloat`, `AsFloat`, `IsDouble`, `AsDouble`, `IsDecimal`, `AsDecimal`.
- `TrimToMaxLength` extension method to trim the string to a specified maximum length.
- `Contains` extension methods for substring matching.
- `Remove` extension methods to remove specified characters or substrings from the string.
- `Replace` extension methods for string replacement.
- `ToTitleCase` extension methods to convert the string to title case.
- `SpaceOnUpper` extension method to insert a space before each uppercase character.
- `IsLike` and `IsLikeAny` extension methods for pattern matching.
- `IsNumber` extension method to check if the string represents a number.
- `Reverse` extension method to reverse the order of characters in the string.