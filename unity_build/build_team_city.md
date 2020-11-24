# Build pipeline TeamCity
Since Jenkins is such a pain to work with we have migrated over to TeamCity instead.


## Installation

### TeamCity server

Deploy the [official docker image](https://hub.docker.com/r/jetbrains/teamcity-server) to our Kubernetes cluster.

### Postgres

Deploy the [official docker image](https://hub.docker.com/_/postgres) to our Kubernetes cluster.

Create the database and user:
```
CREATE DATABASE team_city;
CREATE USER team_city WITH PASSWORD "xyz";
GRANT ALL PRIVILEGES ON DATABASE team_city TO team_city;
```

### Agent

Once the server is up and running you need to download the agent on the machine that will be doing the actual builds.


## TeamCity plugins
* [Unity plugin](https://github.com/JetBrains/teamcity-unity-plugin)


## TeamCity config
Start out by creating a project for the game you are setting up. This top level project will hold settings general to all platforms the game will be built for.

### VCS root
The main thing that lives on the top level project is the VCS root which describes where TeamCity should fetch the project from.
