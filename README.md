# back-end
Back-end API for Romanian BACALAUREAT programming exam guidance app

## Overview
This is a .NET 9 Web API that provides exam questions and guidance for solving Romanian BACALAUREAT programming exams. The API allows users to retrieve exam questions, filter them by various criteria, and get step-by-step hints to solve them.

## Features
- Retrieve all exam questions
- Get specific question by ID
- Filter questions by difficulty (Easy, Medium, Hard)
- Filter questions by subject (Arrays, Algorithms, Sorting, Numbers, etc.)
- Filter questions by year
- Get hints/guidance for each question
- Progressive hint system (hints ordered by difficulty)

## API Endpoints

### Questions
- `GET /api/questions` - Get all exam questions
- `GET /api/questions/{id}` - Get a specific question by ID
- `GET /api/questions/difficulty/{difficulty}` - Get questions by difficulty
- `GET /api/questions/subject/{subject}` - Get questions by subject
- `GET /api/questions/year/{year}` - Get questions by year
- `POST /api/questions` - Add a new question

### Hints
- `GET /api/questions/{questionId}/hints` - Get all hints for a question
- `GET /api/questions/{questionId}/hints/{order}` - Get a specific hint by order number

## Running the API

### Prerequisites
- .NET 9.0 SDK

### Build
```bash
cd BacExamApi
dotnet build
```

### Run
```bash
cd BacExamApi
dotnet run
```

The API will be available at `http://localhost:5000` (or the port configured in launchSettings.json)

### Example Requests

Get all questions:
```bash
curl http://localhost:5000/api/questions
```

Get a specific question:
```bash
curl http://localhost:5000/api/questions/1
```

Get hints for a question:
```bash
curl http://localhost:5000/api/questions/1/hints
```

Get easy questions:
```bash
curl http://localhost:5000/api/questions/difficulty/Easy
```

## Data Models

### ExamQuestion
- `Id`: Question identifier
- `Title`: Question title
- `Description`: Full problem description
- `Difficulty`: Difficulty level (Easy, Medium, Hard)
- `Subject`: Subject area (Arrays, Algorithms, etc.)
- `Year`: Exam year
- `ExampleInput`: Sample input data
- `ExampleOutput`: Expected output
- `Constraints`: Problem constraints
- `Hints`: Collection of hints for solving the question

### Hint
- `Id`: Hint identifier
- `Content`: Hint text
- `Order`: Sequential order (1, 2, 3...)
- `Type`: Hint type (Approach, Algorithm, Implementation, Optimization)
- `ExamQuestionId`: Reference to parent question

## Sample Data
The API comes pre-loaded with sample Romanian BACALAUREAT programming questions including:
1. Sum of even elements in an array
2. Prime number checker
3. Array sorting
4. Number reversal

