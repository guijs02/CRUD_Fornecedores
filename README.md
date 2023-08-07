Este repositório é um sistema de cadastro de fornecedores desenvolvido em .NET CORE, sendo estruturado como um projeto profissional com a arquitetura MVC.

Estilo de projeto utilizado:
ASP .NET CORE MVC

Views - Responsavel por exibir paginas html,css,razor ou javascript
<br>

Services: Esta camada será enviada pelo controlador e irá realizar requisições HTTP para a API.
<br>

Controllers: Esta camada é responsavel por receber as requisições do cliente e repassar para algum serviço.
<br>

SistemaWeb.API - esta camada é responsavel por receber as requisições do Front End a fim de realizar o processamento das informações e a persistência no banco de dados e retornar para as Views.
<br>

Controllers: Recebe a requisição solicitada pelo Service e repassa para o Repository
<br>

Repository: Camada interior a do banco de dados reponsável por realizar a consulta, persistencia, modificações e deleções no banco de dados.


