import json
from google import genai

client = genai.Client()


def evaluation_handler(message):
    message = message['Sub3']['Ex1']

    print("HERE REQUEST", message)

    prompt = """
        You will receive the answer of a student.
        You are to grade that answer with an integer from 1 to 5
        Output a brief explanation, then a blank line.
        The last line should contain just a digit [1-5], that being the grade
        and nothing more than that.
    """

    response = client.models.generate_content(
        model="gemini-2.5-flash", contents=json.dumps(
            {"prompt": prompt, "student_answer": message})
    ).text

    if not response:
        return

    print("HERE REASONING", response[:-1])
    print("HERE GRADE", int(response[-1]))


def lambda_handler(event, _):
    msg = json.loads(event['Records'][0]['Sns']['Message'])

    evaluation_handler(msg)
