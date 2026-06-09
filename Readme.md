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
    "DefaultConnection": "your-connection-string"
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

## Database setup steps

## Known limitations
- No authentication
