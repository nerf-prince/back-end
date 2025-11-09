import json
import os
import boto3

sns_client = boto3.client('sns')

def evaluation_handler(incoming_message):
    try:
        topic_arn = os.environ["OUTPUT_TOPIC_ARN"]
    except KeyError:
        print("Error: OUTPUT_TOPIC_ARN environment variable not set.")
        raise 

    for k1, k2 in (
        ('Sub2', 'Ex2'),
        ('Sub2', 'Ex3'),
        ('Sub3', 'Ex1'),
        ('Sub3', 'Ex2'),
        ('Sub3', 'Ex3'),
    ):
        try:
            ex = incoming_message[k1][k2]

            split_message = {
                "path": f"{k1}/{k2}",
                "ex": ex,
            }

            response = sns_client.publish(
                TopicArn=topic_arn,
                Message=json.dumps(split_message)
            )

            print(f"Published message for {k1}/{k2}. MessageId: {response['MessageId']}")

        except KeyError:
            print(f"Warning: Key path {k1}/{k2} not found in incoming message. Skipping.")
        except Exception as e:
            print(f"Error publishing message for {k1}/{k2}: {e}")
            pass


def lambda_handler(event, _):
    for record in event['Records']:
        msg = json.loads(record['Sns']['Message'])
        evaluation_handler(msg)
    
    return {
        'statusCode': 200,
        'body': json.dumps('All messages processed and split successfully.')
    }
