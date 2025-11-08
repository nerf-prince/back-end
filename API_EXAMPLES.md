# API Testing Examples

This file contains sample curl commands to test the BAC Exam API.

## Get all questions
```bash
curl http://localhost:5000/api/questions
```

## Get a specific question by ID
```bash
curl http://localhost:5000/api/questions/1
```

## Get questions by difficulty
```bash
curl http://localhost:5000/api/questions/difficulty/Easy
curl http://localhost:5000/api/questions/difficulty/Medium
```

## Get questions by subject
```bash
curl http://localhost:5000/api/questions/subject/Arrays
curl http://localhost:5000/api/questions/subject/Algorithms
```

## Get questions by year
```bash
curl http://localhost:5000/api/questions/year/2023
```

## Get hints for a question
```bash
curl http://localhost:5000/api/questions/1/hints
```

## Get a specific hint by order
```bash
curl http://localhost:5000/api/questions/1/hints/1
curl http://localhost:5000/api/questions/1/hints/2
```

## Create a new question (POST)
```bash
curl -X POST http://localhost:5000/api/questions \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Test Question",
    "description": "Test description",
    "difficulty": "Easy",
    "subject": "Testing",
    "year": 2025,
    "exampleInput": "input",
    "exampleOutput": "output",
    "constraints": "test constraints",
    "hints": []
  }'
```

## Access Swagger UI
Open your browser to: http://localhost:5000/

## Sample Response Format
Question object:
```json
{
  "id": 1,
  "title": "Suma elementelor pare dintr-un vector",
  "description": "Scrieți un program care citește n numere întregi...",
  "difficulty": "Easy",
  "subject": "Arrays",
  "year": 2023,
  "exampleInput": "5\n2 3 4 5 6",
  "exampleOutput": "12",
  "constraints": "1 ≤ n ≤ 1000",
  "hints": [...]
}
```

Hint object:
```json
{
  "id": 1,
  "content": "Iterați prin toate elementele vectorului",
  "order": 1,
  "type": "Approach",
  "examQuestionId": 1
}
```
