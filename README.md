# Teste-.netcore-angular9
Teste para vaga de .net core e angular 
Projeto que inclui dividas para recuperação onde na consulta é calculada valor após inclusão de juros,
número de parcelas, valor da parcelas e data de vencimento.


# Server
Api feita com .net core 3.1 e entity framework e SQL Server
O Projeto está dividido em: 
 Api 
 Domain
 Infra
 Tests
 executar o comando dotnet restore para baixar as depedencias
 executando o dotnet run a api iniciara na porta 5000, a mesma já tem a documentação em OpenApi (antigo swagger)

 # Client
 Front feito usando angular 9 e materialize, executar o comando npm install, para o mesmo baixar 
 as dependendencias, executar o comando npm start, o aplicativo iniciara na porta 4200.

 # Obs
Dentro do projeto Server, na camada de infra, estão localizadas as migrations,
Na camada de Api alterar o arquivo appsettings.json incluindo a linha de conexão para base SQL Server,
Usando algum prompt de comando, a partir da pasta da Infra, executar o comando abaixo para o entity
atualizar a base dados criando as tabelas.

dotnet ef database update --project .\Paschoalotto.Infra.csproj --startup-project ..\Paschoalotto.Api\Paschoalotto.Api.csproj