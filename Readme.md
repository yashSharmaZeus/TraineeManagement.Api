# Trainee Management API

## Technology Used
- C# / ASP.NET Core Web API
- EF Core InMemory Database
- Swagger

## How to Run

#### Clone GitHub repository 
```bash
git clone https://github.com/yashSharmaZeus/TraineeManagement.Api.git
cd TraineeManagement.Api
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

**Example Request:**
```bash
curl -X 'GET' \
  'http://localhost:5214/api/Health' \
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
Return all trainee from Database
**Example Request:**
```bash
curl -X 'GET' \
  'http://localhost:5214/api/Trainees' \
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
**Example Request:**
```bash
curl -X 'GET' \
  'http://localhost:5214/api/Trainees/1' \
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
**Example Request:**
```bash
curl -X 'POST' \
  'http://localhost:5214/api/Trainees' \
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
**Example Request:**
```bash
curl -X 'PUT' \
  'http://localhost:5214/api/Trainees/1' \
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
**Example Request:**
```bash
curl -X 'DELETE' \
  'http://localhost:5214/api/Trainees/1' \
  -H 'accept: */*'
```
**Example response**
```bash
status code 204
```
### `GET` `/api/trainees?search={query}`
**Example Request:**
```bash
curl -X 'GET' \
  'http://localhost:5214/api/Trainees?search=Amit' \
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

## Known limitations
- InMemory database (not persistent)
- No authentication
