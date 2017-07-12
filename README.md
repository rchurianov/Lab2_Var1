# Lab2_Var1
Practial assignment 2, variant 1 from MSU CMC C# homeworks

This simple console application extends Lab1_Var1 code.

From the user's perspective the apllication perfroms as follows:

* Creates two different `Person` objects with identical data. Checks that references to the objects are different and outputs hashcodes for both objects.
* Creates a `Student` object, adds data to `Exam`s lists and `Credit`s lists and outputs object's data.
* Creates a full copy of the `Student` objects, changes some data in the original `Student` object and prints both objects to check if the copy has changed. The copy should not change.
* Catches exception caused when assigning wrong type value to the `int Group_Number` field of the  `Student` object.
* Prints `Exam`s and `Credit`s of the `Student` by going through an iterator
* Prints `Exam`s with `Grade` higher than 3.

------------------------------------------------------------------------------------------------------------------------------------
Requirements for the `Student`, `Person`, `Exam` and other classes follow.

In `Person` class and in other classes, required  by variant 1 fulfill following tasks:

* override virtual mathod `bool Equals(object obj)`
* define `==` and `!=` operators
* redefine virtual method `int GetHashCode()`

Define interface

```
interface IDdateAndCopy
  { object DeepCopy();
    DateTime Date { get; set; }
  }
```

Implement the `IDateAndCopy` interface in `Exam`, `Student` and `Person` classes.

Add the following fields and methods to the `Person` class:

* redefine virtual method `bool Equals(object obj)`
* define `==` and `!=` operators so that object equality would mean data equality.
* redefine virtual method `int GetHashCode()`
* define virtual method `object DeepCopy()`
* implement `IDateAndCopy` interface.
