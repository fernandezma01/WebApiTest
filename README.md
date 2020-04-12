# WebApiTest
## Autor: Miguel Fernandez
## Objetivo: Test de C# 
## Versión VS: 2019
## Framework: .NetCore 3.1

1) Se expone el endpoint de tipo POST httpHost/Login que recibe un Json con los datos de inicio de sesión:  
  {
	"Usr_id":"Admin",
	"psw":"Admin1*"
  }
  al retornar, devolverá un Json con la siguiente información
  {
    "usr_id": "1",
    "usr_Name": "Administrador"
  }
  Si el login no es válido, el Json devolverá los valores en null.
2) Se expone el endpoint de tipo GET httpHost/NormalizacionDatos/{nombre}
   Si la búsqueda es exitosa, se recibirá un Json con la siguiente estructura:
   {
    "province_Name": "Santa Fe",
    "latitude": -30.7069271588117,
    "longitude": -60.9498369430241
   }
   En caso de que la búsqueda no devuelva resultados se arrojará una Execión te tipo ArgumentException.
