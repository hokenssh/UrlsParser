## URL EXTRACTER

This WEB API application is a developed to extract the URLs from a text that is sent as text/plain to the backend.

The challenge description can be found in **challenge.pdf** file.

It is consists of two projects:

- ASP.net (core) backend (UrlsParser)
- Unit Tests Project (UrlsParser.Tests)

The entry point for a testing the endpoint is a swagger portal which is available under the address: **http://localhost:8090/swagger/index.html**

---

### Prerequisites

* In order to run this application, it is required to install two tools: **Docker** & **Docker Compose**.

    Instructions how to install **Docker** on [Ubuntu](https://docs.docker.com/install/linux/docker-ce/ubuntu/), [Windows](https://docs.docker.com/docker-for-windows/install/), [Mac](https://docs.docker.com/docker-for-mac/install/).

    **Docker Compose** is already included in installation packs for *Windows* and *Mac*, so only Ubuntu users needs to follow [this instructions](https://docs.docker.com/compose/install/).

* In case of running the application without docker environment; DotNet 6.0 is required. 


### How to run it (docker-compose)?

The entire application can be run with a single command on a terminal:

```
$ sudo docker-compose up -d
```

If you want to stop it, use the following command:

```
$ sudo docker-compose down
```

---

### How to run it (command line)?
The backend application can be run using the following command:
```
$ dotnet run --project UrlsParser/UrlsParser.csproj
```

### Unit Tests
The unit tests are executed during the building process using docker env, but if executing them separately is needed, execute this commands:
```
$ dotnet test
```