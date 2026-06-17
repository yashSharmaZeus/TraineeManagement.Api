# Trainee Management API

## Technology Used
- C# / ASP.NET Core Web API
- MySQL Database
- Swagger

## How to Run

#### Clone GitHub repository 
```bash
git clone https://github.com/yashSharmaZeus/TraineeManagement.Api.git
cd TraineeManagement.Api
```
#### Modify Connection string in appsettings.json
```json
"ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=trainee_management;User=<your_mysql_username>;Password=<your_mysql_password>;"
  }
```
#### Apply migration changes to your database
```bash
dotnet ef database update
```
#### Run project
```bash
dotnet run
```

## JWT setup

1. Install required packages
    ```sh
    dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 10.0.9
    dotnet add package System.IdentityModel.Tokens.Jwt --version 8.19.1
   ```


2. Configure JWT settings in appsettings.json
    ```sh
    "Jwt":{
      "Key":"<your_jwt_secret_key>",
      "Issuer":"TraineeManagementApi",
      "Audience":"TraineeManagementClient"
    }
   ``` 
  
## Default Admin credential
Username: Admin
Password: Admin@123

## API list
| Method | EndPoint | 
|:---|:---|
|`GET` |  `/api/health` | 
|`GET` |  `/api/trainees` | 
|`GET` |  `/api/trainees/{id}` | 
|`POST` |  `/api/trainees` | 
|`PUT` |  `/api/trainees/{id}` | 
|`DELETE` |  `/api/trainees/{id}` | 
|`GET` |  `/api/trainees?search={query}` | 
|`GET` | ` /api/mentors` |
|`GET` | ` /api/mentors/{id}` |
|`POST` | ` /api/mentors` |
|`PUT` | ` /api/mentors/{id}` |
|`DELETE` | ` /api/mentors/{id}` |
|`GET` | ` /api/learning-tasks` |
|`GET` | ` /api/learning-tasks/{id}` |
|`POST` | ` /api/learning-tasks` |
|`PUT` | ` /api/learning-tasks/{id}` |
|`DELETE` | ` /api/learning-tasks/{id}` |
|`POST` | ` /api/task-assignments` |
|`GET` | ` /api/task-assignments` |
|`GET` | ` /api/task-assignments/{id}` |
|`PUT` | ` /api/task-assignments/{id}/status` |
|`POST` | ` /api/submissions` |
|`GET` | ` /api/submissions` |
|`GET` | ` /api/submissions/{id}` |
|`POST` | ` /api/reviews` |
|`GET` | ` /api/reviews` |
|`GET` | ` /api/reviews/{id}` |


## samples

### `GET` `/api/health`

**Description:**
 Returns the current health status of the application along with a timestamp.
 
**Example Request:**
```bash
curl -X 'GET' \
  'https://<YOUR_BASE_URL>/api/Health' \
  -H 'accept: */*'
```
**Example Response**
```json
{
  "status": "running",
  "application": "Trainee Management API",
  "timestamp": "2026-06-08T16:04:12"
}
```

### `GET` `/api/trainees`

**Description:**
Retrieves all trainees. Supports optional search functionality using the search query parameter.

**Example Request:**
```bash
curl -X 'GET' \
  'https://<YOUR_BASE_URL>/api/Trainees' \
  -H 'accept: */*'
```
**Example response**
```json
{
    "pageNumber": 1,
    "pageSize": 10,
    "totalRecords": 1,
    "data": 
      [
        {
          "id": 4,
          "firstName": "Amit",
          "lastName": "Sharma",
          "email": "amit.sharma@training.com",
          "techStack": "HTML, CSS, JavaScript",
          "status": "Active",
          "createdDate": "2026-06-08T16:22:17",
          "updatedDate": "2026-06-08T16:22:17"
        },
        {
          "id": 5,
          "firstName": "Sumit",
          "lastName": "Sharma",
          "email": "amit.sharma@training.com",
          "techStack": "HTML, CSS, JavaScript",
          "status": "Active",
          "createdDate": "2026-06-08T16:22:29",
          "updatedDate": "2026-06-08T16:22:29"
        }
      ]
}
```
### `GET` `/api/trainees/{id}`

**Description:**
	Retrieves a specific trainee by their unique identifier.

**Example Request:**
```bash
curl -X 'GET' \
  'https://<YOUR_BASE_URL>/api/Trainees/1' \
  -H 'accept: */*'
```
**Example response**
```json
{
  "id": 1,
  "firstName": "Amit",
  "lastName": "Sharma",
  "email": "amit.sharma@training.com",
  "techStack": "HTML, CSS, JavaScript",
  "status": "Active",
  "createdDate": "2026-06-08T16:22:29",
  "updatedDate": "2026-06-08T16:22:29"
}
```
### `POST` `/api/trainees`

**Description:**
Creates a new trainee record and returns the created trainee details

**Example Request:**
```bash
curl -X 'POST' \
  'https://<YOUR_BASE_URL>/api/Trainees' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{  
          "firstName": "Amit",
          "lastName": "Sharma",
          "email": "amit.sharma@training.com",
          "techStack": "HTML, CSS, JavaScript",
          "status": "Active"
     }'
```
**Example response**
```json
{
  "id": 1,
  "firstName": "Amit",
  "lastName": "Sharma",
  "email": "amit.sharma@training.com",
  "techStack": "HTML, CSS, JavaScript",
  "status": "Active",
  "createdDate": "2026-06-08T16:22:29",
  "updatedDate": "2026-06-08T16:22:29"
}
```
### `PUT` `/api/trainees/{id}`

**Description:**
Updates an existing trainee's information by ID.

**Example Request:**
```bash
curl -X 'PUT' \
  'https://<YOUR_BASE_URL>/api/Trainees/1' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
          "firstName": "Amit",
          "lastName": "Sharma",
          "email": "amit.sharma@training.com",
          "techStack": "HTML, CSS, JavaScript",
          "status": "Inactive"
     }'
```
**Example response**
```json
{
  "id": 1,
  "firstName": "Amit",
  "lastName": "Sharma",
  "email": "amit.sharma@training.com",
  "techStack": "HTML, CSS, JavaScript",
  "status": "Inactive",
  "createdDate": "2026-06-08T16:14:02",
  "updatedDate": "2026-06-08T16:16:06"
}
```
### `DELETE` `/api/trainees/{id}`

**Description:**
Deletes a trainee by ID. Returns 204 No Content on success

**Example Request:**
```bash
curl -X 'DELETE' \
  'https://<YOUR_BASE_URL>/api/Trainees/1' \
  -H 'accept: */*'
```
**Example response**
```bash
status code 204
```
### `GET` `/api/trainees?search={query}`

**Description:**
Searches trainees by first name, last name, email, or tech stack.

**Example Request:**
```bash
curl -X 'GET' \
  'https://<YOUR_BASE_URL>/api/Trainees?search=Amit' \
  -H 'accept: */*'
```
**Example response**
```json
[
  {
    "id": 1,
    "firstName": "Amit",
    "lastName": "Sharma",
    "email": "amit.sharma@training.com",
    "techStack": "HTML, CSS, JavaScript",
    "status": "Inactive",
    "createdDate": "2026-06-08T16:14:02",
    "updatedDate": "2026-06-08T16:16:06"
  },
  {
    "id": 2,
    "firstName": "Amit",
    "lastName": "Verma",
    "email": "amit.sharma1@training.com",
    "techStack": "HTML, CSS, JavaScript",
    "status": "Inactive",
    "createdDate": "2026-06-08T16:14:02",
    "updatedDate": "2026-06-08T16:16:06"
  }
]
```

### `POST` `/api/auth/login`

**Description:**
validate user using username , password and JWT

**Example Request:**
```bash
curl -X 'POST' \
  'http://localhost:5214/api/auth/Login' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
    "username": "Admin",
    "password": "Admin@123"
}'
```
**Example response**
```json
{
  "jwtTokenValue": "jwt-token-value",
  "expiresIn": 3600,
  "user": {
    "id": 1,
    "username": "Admin",
    "role": "Admin"
  }
}
```

### `GET` `/api/mentors` 
**Description:**
Retrieves all Mentor. Supports optional search functionality using the search query parameter.

**Example Request:**
```bash
curl --location 'http://localhost:5214/api/mentors' \
--header 'Authorization: Bearer <jwt-token>'
```
**Example response**
```json
{
    "pageNumber": 1,
    "pageSize": 10,
    "totalRecords": 1,
    "data": [
        {
            "id": 1,
            "firstName": "mentorName",
            "lastName": "mentorLastName",
            "email": "name.test@gmail.com",
            "expertise": "HTML",
            "status": "Inactive",
            "createdDate": "2026-06-16T07:13:14",
            "updatedDate": "2026-06-16T07:13:51"
        }
    ]
}
```

### `GET` `/api/mentors/{id}` 
**Description:**
	Retrieves a specific Mentor by their unique identifier.
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/mentors/1' \
--header 'Authorization: Bearer <jwt-token>'
```
**Example response**
```json
{
    "id": 1,
    "firstName": "mentorName",
    "lastName": "mentorLastName",
    "email": "name.test@gmail.com",
    "expertise": "HTML",
    "status": "Inactive",
    "createdDate": "2026-06-16T07:13:14",
    "updatedDate": "2026-06-16T07:13:51"
}
```

### `POST` `/api/mentors` 
**Description:**
Create New mentor and return the created Mentor detail.
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/mentors/' \
--header 'Authorization: Bearer <jwt-token>' \
--header 'Content-Type: application/json' \
--data-raw '{
  "firstName": "Mentor-First-Name",
  "lastName": "Mentor-Last-Name",
  "email": "mentor@email.com",
  "expertise": "dotnet",
  "status": "Active"
}'
```
**Example response**
```json
{
    "id": 2,
    "firstName": "Mentor-First-Name",
    "lastName": "Mentor-Last-Name",
    "email": "mentor@email.com",
    "expertise": "dotnet",
    "status": "Active",
    "createdDate": "2026-06-17T09:49:51",
    "updatedDate": "2026-06-17T09:49:51"
}
```

### `PUT` `/api/mentors/{id}` 
**Description:**
Update detail of Mentor with matching Id.
**Example Request:**
```bash
curl --location --request PUT 'http://localhost:5214/api/mentors/2' \
--header 'Authorization: Bearer <jwt-token>' \
--header 'Content-Type: application/json' \
--data-raw '{
    "firstName": "Mentor-First-Name",
    "lastName": "Mentor-Last-Name",
    "email": "mentor@email.com",
    "expertise": "Angular",
    "status": "Active"
}'
```
**Example response**
```json
{
    "id": 2,
    "firstName": "Mentor-First-Name",
    "lastName": "Mentor-Last-Name",
    "email": "mentor@email.com",
    "expertise": "Angular",
    "status": "Active",
    "createdDate": "2026-06-17T09:49:51",
    "updatedDate": "2026-06-17T09:51:57"
} 
```

### `DELETE` `/api/mentors/{id}` 
**Description:**
Delete Mentor with matching id
**Example Request:**
```bash
curl --location --request DELETE 'http://localhost:5214/api/mentors/2' \
--header 'Authorization: Bearer <jwt-token>'
```
**Example response**
```json
status: 204 No Content
```

### `GET` `/api/learning-tasks` 
**Description:**
Retrieves all learning task.
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/learning-tasks' \
--header 'Authorization: Bearer <jwt-token>'
```
**Example response**
```json
{
    "pageNumber": 1,
    "pageSize": 10,
    "totalRecords": 1,
    "data": [
        {
            "id": 1,
            "title": "string",
            "description": "string",
            "expectedTechStack": "string",
            "dueDate": "2026-06-16T07:14:14.988",
            "status": "Draft",
            "createdDate": "2026-06-16T07:14:55",
            "updatedDate": "2026-06-16T07:14:55"
        }
    ]
}
```

### `GET` `/api/learning-tasks/{id}` 
**Description:**
Retrieves learning tak with matching id.
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/learning-tasks/1' \
--header 'Authorization: Bearer <jwt-token>'
```
**Example response**
```json
{
    "id": 1,
    "title": "string",
    "description": "string",
    "expectedTechStack": "string",
    "dueDate": "2026-06-16T07:14:14.988",
    "status": "Draft",
    "createdDate": "2026-06-16T07:14:55",
    "updatedDate": "2026-06-16T07:14:55"
}
```

### `POST` `/api/learning-tasks` 
**Description:**
Add new learning task.
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/learning-tasks/' \
--header 'Authorization: Bearer <jwt-token>' \
--header 'Content-Type: application/json' \
--data '{
  "title": "Learning Task 1",
  "description": "task description",
  "expectedTechStack": "JAVA",
  "dueDate": "2026-06-17T10:10:49.052Z",
  "status": "Published"
}'
```
**Example response**
```json
{
    "id": 2,
    "title": "Learning Task 1",
    "description": "task description",
    "expectedTechStack": "JAVA",
    "dueDate": "2026-06-17T10:10:49.052Z",
    "status": "Published",
    "createdDate": "2026-06-17T10:14:28",
    "updatedDate": "2026-06-17T10:14:28"
}
```

### `PUT` `/api/learning-tasks/{id}` 
**Description:**
Update detail of learning task with matching Id.
**Example Request:**
```bash
curl --location --request PUT 'http://localhost:5214/api/learning-tasks/2' \
--header 'Authorization: Bearer <jwt-token>' \
--header 'Content-Type: application/json' \
--data '{
  "title": "Learning Task 1",
  "description": "task description",
  "expectedTechStack": "JAVA",
  "dueDate": "2026-06-17T10:10:49.052Z",
  "status": "Draft"
}'
```
**Example response**
```json
{
    "id": 2,
    "title": "Learning Task 1",
    "description": "task description",
    "expectedTechStack": "JAVA",
    "dueDate": "2026-06-17T10:10:49.052Z",
    "status": "Draft",
    "createdDate": "2026-06-17T10:14:28",
    "updatedDate": "2026-06-17T10:18:04"
}
```

### `DELETE` `/api/learning-tasks/{id}` 
**Description:**
Delete learning task with matching Id.
**Example Request:**
```bash
curl --location --request DELETE 'http://localhost:5214/api/learning-tasks/2' \
--header 'Authorization: Bearer <jwt-token>'
```
**Example response**
```json
status: 204 No Content
```

### `GET` `/api/task-assignments` 
**Description:**
Retrieves all task assignment.
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/task-assignments' \
--header 'Authorization: Bearer <jwt-token>'
```
**Example response**
```json
[
    {
        "id": 1,
        "traineeId": 1,
        "mentorId": 1,
        "learningTaskId": 1,
        "assignedDate": "2026-06-16T07:14:01.852",
        "dueDate": "2026-06-16T07:14:01.852",
        "status": "Assigned",
        "remarks": "string"
    }
]
```

### `GET` `/api/task-assignments/{id}` 
**Description:**
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/task-assignments/1' \
--header 'Authorization: Bearer <jwt-token>'
```
**Example response**
```json
{
    "id": 1,
    "traineeId": 1,
    "mentorId": 1,
    "learningTaskId": 1,
    "assignedDate": "2026-06-16T07:14:01.852",
    "dueDate": "2026-06-16T07:14:01.852",
    "status": "Assigned",
    "remarks": "string"
}
```

### `POST` `/api/task-assignments` 
**Description:**
Add new Task assignment and return new task assignment.
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/task-assignments' \
--header 'Authorization: Bearer <jwt-token>' \
--header 'Content-Type: application/json' \
--data '{
  "traineeId": 1,
  "mentorId": 1,
  "learningTaskId": 1,
  "assignedDate": "2026-06-17T10:30:27.879Z",
  "dueDate": "2026-06-17T10:30:27.879Z",
  "status": "Assigned",
  "remarks": "Good"
}'
```
**Example response**
```json
{
    "id": 2,
    "traineeId": 1,
    "mentorId": 1,
    "learningTaskId": 1,
    "assignedDate": "2026-06-17T10:30:27.879Z",
    "dueDate": "2026-06-17T10:30:27.879Z",
    "status": "Assigned",
    "remarks": "Good"
}
```

### `PUT` `/api/task-assignments/{id}/status` 
**Description:**
Update status of task assignment of matching id.
**Example Request:**
```bash
curl --location --request PUT 'http://localhost:5214/api/task-assignments/2/status' \
--header 'Authorization: Bearer <jwt-token>' \
--header 'Content-Type: application/json' \
--data '{
          "status": "InProgress"
        }'
```
**Example response**
```json
{
    "id": 2,
    "traineeId": 1,
    "mentorId": 1,
    "learningTaskId": 1,
    "assignedDate": "2026-06-17T10:30:27.879",
    "dueDate": "2026-06-17T10:30:27.879",
    "status": "InProgress",
    "remarks": "Good"
}
```


### `GET` `/api/submissions` 
**Description:**
Retrieves all submission.
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/submissions' \
--header 'Authorization: Bearer <jwt-token>'
```
**Example response**
```json
[
    {
        "id": 1,
        "taskAssignmentId": 1,
        "submissionUrl": "string",
        "notes": "string",
        "status": "Submitted",
        "submittedDate": "2026-06-16T07:22:07.138"
    }
]
```


### `GET` `/api/submissions/{id}` 
**Description:**
Retrieves submission with matching id. 
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/submissions/1' \
--header 'Authorization: Bearer <jwt-token>'
```
**Example response**
```json
{
    "id": 1,
    "taskAssignmentId": 1,
    "submissionUrl": "string",
    "notes": "string",
    "status": "Submitted",
    "submittedDate": "2026-06-16T07:22:07.138"
}
```

### `POST` `/api/submissions` 
**Description:**
Add new submission and return detail of submission.
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/submissions/' \
--header 'Authorization: Bearer <jwt-token>' \
--header 'Content-Type: application/json' \
--data '{
  "taskAssignmentId": 1,
  "submissionUrl": "http://submission.com?id=1",
  "notes": "working correctly",
  "submittedDate": "2026-06-17T10:41:35.984Z",
  "status": "Submitted"
}'
```
**Example response**
```json
{
    "id": 4,
    "taskAssignmentId": 1,
    "submissionUrl": "http://submission.com?id=1",
    "notes": "working correctly",
    "status": "Submitted",
    "submittedDate": "2026-06-17T10:41:35.984Z"
}
```

### `GET` `/api/reviews` 
**Description:**
Retrieves all review.
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/reviews' \
--header 'Authorization: Bearer <jwt-token>'
```
**Example response**
```json
[
  {
    "id": 1,
        "submissionId": 1,
        "mentorId": 1,
        "feedback": "string",
        "score": 37,
        "reviewStatus": "Accepted",
        "reviewedDate": "2026-06-16T07:22:32.355"
    }
]
```

### `GET` `/api/reviews/{id}` 
**Description:**
Retrieves review with matching Id.
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/reviews/1' \
--header 'Authorization: Bearer <jwt-toke>'
```
**Example response**
```json
{
    "id": 1,
    "submissionId": 1,
    "mentorId": 1,
    "feedback": "string",
    "score": 37,
    "reviewStatus": "Accepted",
    "reviewedDate": "2026-06-16T07:22:32.355"
}
```

### `POST` `/api/reviews` 
**Description:**
Add new review and return detail of created review.
**Example Request:**
```bash
curl --location 'http://localhost:5214/api/reviews/' \
--header 'Authorization: Bearer <jwt-token>' \
--header 'Content-Type: application/json' \
--data '{
  "submissionId": 1,
  "mentorId": 1,
  "feedback": "string",
  "score": 1,
  "reviewStatus": "ChangesRequired",
  "reviewedDate": "2026-06-17T10:49:29.588Z"
}'
```
**Example response**
```json
{
    "id": 2,
    "submissionId": 1,
    "mentorId": 1,
    "feedback": "string",
    "score": 1,
    "reviewStatus": "ChangesRequired",
    "reviewedDate": "2026-06-17T10:49:29.588Z"
}
```
