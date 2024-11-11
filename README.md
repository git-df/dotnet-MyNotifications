# Notification Service

## Getting Started

### Prerequisites
- Docker and Docker Compose installed on your machine.

### Installation

1. Clone the repository and navigate to the project directory.

```bash
git clone https://github.com/git-df/dotnet-MyNotifications.git
cd dotnet-MyNotifications
```
   
3. Configure environment variables

- Required:
  - DiscordOptions__WebhookUrl (for mn.sender) - Webhook URL [Documentation of discord webhooks](https://support.discord.com/hc/en-us/articles/228383668-Intro-to-Webhooks)

- Optional:
  - RABBITMQ_DEFAULT_USER (mn.rabbitmq) - RabbitMQ user name
  - RABBITMQ_DEFAULT_PASS (mn.rabbitmq) - RabbitMQ user password
  - POSTGRES_USER (mn.database) - Database user name
  - POSTGRES_PASSWORD (mn.database) - Database user password
  - POSTGRES_DB (mn.database) -  Database name
  - ConnectionStrings__DefaultConnection (mn.database.migrator) - Database connection string
  - RabbitMqOptions__HostUri (mn.api) - RabbitMQ connection uri (amqp://name:password@host:5672)
  - ConnectionStrings__DefaultConnection (mn.api) - Database connection string
  - RabbitMqOptions__HostUri (mn.sender) - RabbitMQ connection uri (amqp://name:password@host:5672)
  - ConnectionStrings__DefaultConnection (mn.sender) - Database connection string
   
5. Run Docker Compose

```bash
docker-compose up --build -d
```

6. Go to swagger GUI

```bash
http://localhost:8080/swagger/index.html
```

## C4 Diagram

![DailyDishService_job](https://dawidflorian.pl/file/MyNotification/C4.png)

## API

### Open API
<details>
  <summary>Click me</summary>
   
```json
{
  "x-generator": "NSwag v14.1.0.0 (NJsonSchema v11.0.2.0 (Newtonsoft.Json v13.0.0.0))",
  "openapi": "3.0.0",
  "info": {
    "title": "MyNotifications.Api",
    "version": "1.0.0"
  },
  "servers": [
    {
      "url": "http://localhost:8080"
    }
  ],
  "paths": {
    "/notifications": {
      "post": {
        "tags": [
          "Notifications"
        ],
        "operationId": "MyNotificationsApiEndpointsSendNotificationSendNotificationEndpoint",
        "requestBody": {
          "x-name": "SendNotificationRequest",
          "description": "",
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/MyNotificationsApiEndpointsSendNotificationSendNotificationRequest"
              }
            }
          },
          "required": true,
          "x-position": 1
        },
        "responses": {
          "200": {
            "description": "Success",
            "content": {
              "text/plain": {
                "schema": {}
              },
              "application/json": {
                "schema": {}
              }
            }
          },
          "400": {
            "description": "Bad Request",
            "content": {
              "application/problem+json": {
                "schema": {
                  "$ref": "#/components/schemas/FastEndpointsErrorResponse"
                }
              }
            }
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "FastEndpointsErrorResponse": {
        "type": "object",
        "additionalProperties": false,
        "properties": {
          "statusCode": {
            "type": "integer",
            "format": "int32",
            "default": 400
          },
          "message": {
            "type": "string",
            "default": "One or more errors occurred!"
          },
          "errors": {
            "type": "object",
            "additionalProperties": {
              "type": "array",
              "items": {
                "type": "string"
              }
            }
          }
        }
      },
      "MyNotificationsApiEndpointsSendNotificationSendNotificationRequest": {
        "type": "object",
        "additionalProperties": false,
        "required": [
          "request"
        ],
        "properties": {
          "request": {
            "nullable": false,
            "$ref": "#/components/schemas/MyNotificationsDomainModelModelsWebhookRequest"
          }
        }
      },
      "MyNotificationsDomainModelModelsWebhookRequest": {
        "type": "object",
        "additionalProperties": false,
        "required": [
          "content"
        ],
        "properties": {
          "username": {
            "type": "string",
            "nullable": true
          },
          "avatarUrl": {
            "type": "string",
            "nullable": true
          },
          "content": {
            "type": "string",
            "minLength": 1,
            "nullable": false
          },
          "embeds": {
            "type": "array",
            "nullable": true,
            "items": {
              "$ref": "#/components/schemas/MyNotificationsDomainModelModelsEmbed"
            }
          }
        }
      },
      "MyNotificationsDomainModelModelsEmbed": {
        "type": "object",
        "additionalProperties": false,
        "properties": {
          "author": {
            "nullable": true,
            "oneOf": [
              {
                "$ref": "#/components/schemas/MyNotificationsDomainModelModelsAuthor"
              }
            ]
          },
          "title": {
            "type": "string",
            "nullable": true
          },
          "url": {
            "type": "string",
            "nullable": true
          },
          "description": {
            "type": "string",
            "nullable": true
          },
          "color": {
            "type": "integer",
            "format": "int32",
            "nullable": true
          },
          "fields": {
            "type": "array",
            "nullable": true,
            "items": {
              "$ref": "#/components/schemas/MyNotificationsDomainModelModelsField"
            }
          },
          "thumbnail": {
            "nullable": true,
            "oneOf": [
              {
                "$ref": "#/components/schemas/MyNotificationsDomainModelModelsUrlObject"
              }
            ]
          },
          "image": {
            "nullable": true,
            "oneOf": [
              {
                "$ref": "#/components/schemas/MyNotificationsDomainModelModelsUrlObject"
              }
            ]
          },
          "footer": {
            "nullable": true,
            "oneOf": [
              {
                "$ref": "#/components/schemas/MyNotificationsDomainModelModelsFooter"
              }
            ]
          }
        }
      },
      "MyNotificationsDomainModelModelsAuthor": {
        "type": "object",
        "additionalProperties": false,
        "properties": {
          "name": {
            "type": "string",
            "nullable": true
          },
          "url": {
            "type": "string",
            "nullable": true
          },
          "iconUrl": {
            "type": "string",
            "nullable": true
          }
        }
      },
      "MyNotificationsDomainModelModelsField": {
        "type": "object",
        "additionalProperties": false,
        "properties": {
          "name": {
            "type": "string",
            "nullable": true
          },
          "value": {
            "type": "string",
            "nullable": true
          },
          "inline": {
            "type": "boolean",
            "nullable": true
          }
        }
      },
      "MyNotificationsDomainModelModelsUrlObject": {
        "type": "object",
        "additionalProperties": false,
        "properties": {
          "url": {
            "type": "string",
            "nullable": true
          }
        }
      },
      "MyNotificationsDomainModelModelsFooter": {
        "type": "object",
        "additionalProperties": false,
        "properties": {
          "text": {
            "type": "string",
            "nullable": true
          },
          "iconUrl": {
            "type": "string",
            "nullable": true
          }
        }
      }
    },
    "securitySchemes": {
      "JWTBearerAuth": {
        "type": "http",
        "description": "Enter a JWT token to authorize the requests...",
        "scheme": "Bearer",
        "bearerFormat": "JWT"
      }
    }
  }
}
```
</details>
