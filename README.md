# CourseApi
The Course API is a RESTful web service that allows you to manage courses, students, and teachers. It provides endpoints for creating, retrieving, updating, and deleting courses, students, and teachers. Additionally, it supports operations to associate students with courses and retrieve a list of students for a specific course.
## Endpoints
### Courses
* **GET /api/courses:** Retrieves a list of all courses.
* **GET /api/courses/{id}:** Retrieves a specific course by its ID.
  * **Sample Request**: GET /api/courses/1
* **PUT /api/courses/{id}:** Updates an existing course.
  * **Sample Request**: PUT /api/courses/1
    ```
    Request Body:
    {
      "id": 1,
      "name": "New Course Name",
      "description": "Updated course description",
      "ownerId": 2
    }
    ```
* **POST /api/courses:** Creates a new course.
  * **Sample Request**: POST /api/courses
    ```
    Request Body:
    {
      "name": "New Course",
      "description": "Course description",
      "ownerId": 1
    }
    ```
* **DELETE /api/courses/{id}:** Deletes a course by its ID.
  * **Sample Request:** DELETE /api/courses/1 
* **GET /api/courses/{id}/students:** Retrieves a list of students enrolled in a specific course.
  * **Sample Request:** GET /api/courses/1/students
* **POST /api/courses/{id}/add-student/{studentId}:** Enrolls a student in a course.
  * **Sample Request:** POST /api/courses/1/add-student/2
* **DELETE /api/courses/{id}/remove-student/{studentId}:** Removes a student from a course.
  * **Sample Request:** DELETE /api/courses/{id}/remove-student/{studentId}
### Students
* **GET /api/students:** Retrieves a list of all students.
* **GET /api/students/{id}:** Retrieves a specific student by their ID.
  * **Sample Request:** GET /api/students/1
* **PUT /api/students/{id}:** Updates an existing student.
  * **Sample Request:** PUT /api/students/1
    ```
    Request Body:
    {
      "id": 1,
      "name": "Updated Student Name",
      "age": 25
    }
    ```
* **POST /api/students:** Creates a new student.
  * **Sample Request:** POST /api/students
    ```
    Request Body:
    {
      "name": "New Student",
      "age": 20
    }
    ```
* **DELETE /api/students/{id}:** Deletes a student by their ID.
  * **Sample Request:** DELETE /api/students/1
### Teachers
* **GET /api/teachers:** Retrieves a list of all teachers.
* **GET /api/teachers/{id}:** Retrieves a specific teacher by their ID.
  * **Sample Request:** GET /api/teachers/1
* **PUT /api/teachers/{id}:** Updates an existing teacher.
  * **Sample Request:** PUT /api/teachers/1
    ```
    Request Body:
    {
      "id": 1,
      "name": "Updated Teacher Name",
      "age": 35
    }
    ```
* **POST /api/teachers:** Creates a new teacher.
  * **Sample Request:** POST /api/teachers
    ```
    Request Body:
    {
      "name": "New Teacher",
      "age": 30
    }
    ```
* **DELETE /api/teachers/{id}:** Deletes a teacher by their ID.
  * **Sample Request:** DELETE /api/teachers/1
## Data Models
The API works with the following data models:
### Course
* **Id (integer):** The unique identifier of the course.
* **Name (string, required):** The name of the course.
* **Description (string):** The description of the course.
* **OwnerId (integer, required):** The ID of the teacher who owns the course.
* **Teacher (Teacher object):** The teacher who owns the course.
* **StudentCourses (list of StudentCourses objects):** The list of student-course associations.
### Student
* **Id (integer):** The unique identifier of the student.
* **Name (string, required):** The name of the student.
* **Age (integer):** The age of the student.
* **StudentCourses (list of StudentCourses objects):** The list of student-course associations.
### Teacher
* **Id (integer):** The unique identifier of the teacher.
* **Name (string, required):** The name of the teacher.
* **Age (integer):** The age of the teacher.
### StudentCourses
* **Id (integer):** The unique identifier of the student-course association.
* **StudentId (integer):** The ID of the student.
* **CourseId (integer):** The ID of the course.
* **JoinedAt (datetime):** The date and time when the student joined the course.
* **Student (Student object):** The student associated with the student-course association.
* **Course (Course object):** The course associated with the student-course association.
## Getting Started
To use the Course API, follow these steps:
1. Ensure you have the necessary authentication credentials, if required.
2. Make requests to the appropriate endpoints using a tool such as Postman or cURL.
3. View and analyze the responses received.
## Error Handling
The API will return appropriate status codes and error messages in case of invalid requests or errors during processing. Ensure you handle these responses properly in your application.
## Dependencies
* The Course API is built using the following technologies and frameworks:
* .NET Core: The framework used to build the API.
* Entity Framework Core: The ORM used for database operations.
* Microsoft SQL Server: The database used to store course, student, and teacher data.
* ASP.NET Core Web API: The framework used to build the RESTful API.
