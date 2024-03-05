# The Todos Resource

`/todos` - Resources in HTTP are just "an important thingy that supports some of the HTTP interface"

- Interface:
    - GET (retrieve a representation of that resouce.)
    - POST (append the sent representation of the collection)
    - PUT (replace a resource with a new represenation)
    - DELETE (remove a resource)
## Let the user add an item to their todo list

Send Request
```http
POST /todos
Accept: application/json
content-Typer: application/json

{
    "description": "Clean Garage"
}
```http
201 Created
Content-Type: application/json
Location: http://localhost:1337/todos/389389893

{
    "id": "389389893",
}
## Let the user see the items on their todo list

### See All Items on their Todo list

### See Just the Incomplete 