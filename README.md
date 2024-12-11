# Random Info API

Obtén información aleatoria

Puedes probar el funcionamiento de la API en el `index.html` una vez que hayas construido y desplegado el contenedor en docker. 

## Construir y ejecutar en Docker

```Docker
  docker build -t randominfo:1.0 .
  docker run --rm -it -p 80:8080/tcp randominfo:1.0
```

De esta forma podrás acceder a la API desde `http://localhost/randominfo/`
