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
## C4 Diagram

![DailyDishService_job](https://dawidflorian.pl/file/MyNotification/C4.png)
