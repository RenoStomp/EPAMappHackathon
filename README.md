# Zameshhauripsicititki.API

### This is the API for the Zameshhauripsicititki project. 

It provides endpoints for managing ***notes***, ***admins*** and ***user*** accounts.

## Installation

* Clone this repository.

* Open the solution file (Zameshhauripsicititki.sln) in Visual Studio.

* Build the solution.

## Requirements

**To run the project, the following is required:**

* .NET 5.0 Runtime

* Visual Studio 2019 or later

## Running the Project

**To run the project, follow these steps:**

* Clone the repository to your computer:
```
git clone https://github.com/your-username/your-repo.git
```
* Open the project in Visual Studio.

* Run the project in Visual Studio.

* Open Swagger or another API testing tool and test the API endpoints.

## Usage

#### Note Endpoints

**GET /api/Note**

*Returns a list of all notes.*

#### Responses:

* 200 OK: The list of notes is returned in the response body.

## POST /api/Note

*Creates a new note.*

***Request body:***

```
{
  "title": "string",
  "content": "string"
}
```

#### Responses:

* 200 OK: The note was created successfully.

## PUT /api/Note

*Updates an existing note.*

***Request body:***

```
{
  "id": 0,
  "title": "string",
  "content": "string"
}
```

#### Responses:

* 200 OK: The note was updated successfully.

## GET /api/Note/{id}

***Returns a single note.***

**Parameters:**

* id (integer, required): *The ID of the note to retrieve.*

#### Responses:

* 200 OK: The note is returned in the response body.

## DELETE /api/Note/{id}

***Deletes a single note.***

**Parameters:**

* id (integer, required): The ID of the note to delete.

#### Responses:

* 200 OK: The note was deleted successfully.

## GET /api/Note/{id}/ExporToExcel

***Exports a single note to an Excel file.***

**Parameters:**

* id (integer, required): The ID of the note to export.

#### Responses:

* 200 OK: The Excel file is returned in the response body.

## GET /api/Note/{id}/LastWeekReport

***Generates a report of notes created in the last week.***

**Parameters:**

* id (integer, required): The ID of the user to generate the report for.

#### Responses:

* 200 OK: The report is returned in the response body.

## GET /api/Note/{id}/LastWeekReport2

***Generates a report of notes created in the last week, grouped by day.***

**Parameters:**

* id (integer, required): The ID of the user to generate the report for.

#### Responses:

* 200 OK: The report is returned in the response body.


## API Documentation
*This API follows the OpenAPI 3.0.1 specification. You can view the documentation and the rest of endpoints by opening the swagger.json file in an OpenAPI viewer.*
