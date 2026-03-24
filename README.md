Design decisions

1)Equipment is abstract to share common fields and allow extensions
2)Business logic is placed in Rental service instead of models
3)Singleton is used to centralize data storage
4)IRentalService helps with the implementation of a more complex class

Cohesion: each class has one responsibility
Coupling: models are independent from services, interface used for abstraction
