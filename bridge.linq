<Query Kind="Statements" />

//bridge
class Set { }//low level abstract set of items

class DBSet : Set { }//Implements set of items from DB
class APISet : Set { }//Implements set of items from an API

class PersonDBSet : DBSet { }//Implements set of items from DB and queries People table
class ItemDBSet : DBSet { }//Implements set of items from DB and queries Items table
	  	
class PersonAPISet : APISet { }//Implements set of items from API and queries People table
class ItemAPISet : APISet { }//Implements set of items from API and queries Items table

//So, the intersections between abstractions causes the number of classes to rise exponentially
//for example, if you want to use the Transaction table, you would need to implement to classes

//conventional 

class ObjectQueryable{}
class PersonQueryable : ObjectQueryable {}

class RealDBSet : Set{
	private ObjectQueryable _queryable;
} // so we inject the dependency via composition. Kinda like a strategy pattern, I guess

//language-dependant solution

class GDBSet<T> : Set{}
//just use generics to disaptch one branch of abstractions