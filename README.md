# Projeto Bot Discord

  

Projeto pessoal de estudos para fixar os conhecimentos adquiridos nos ultimos meses estudando C#, .NET.

  

Dandara é um bot do Discord que integra a api do chat GPT, trazendo para o chat do Discord a IA da OpenAI.

## Tecnologias utilizadas

- .NET 6
- API OpenAi GPT-3
- Lib Discord.NEt

## Como executar o projeto em ambiente de desenvolvimento

### Pré-requisitos

* Bot App do Discord (você pode criar  [aqui](https://discord.com/developers/applications)).

* API key da OpenAI (você pode obter  [aqui](https://platform.openai.com/account/api-keys)).

* [.NET 6 SDK](https://dotnet.microsoft.com/download)



### Build e Run

- Clonar o repositorio:
```bash
git clone https://github.com/wilsonbrandao/DandaraBotDiscord.git
```

- No terminal, navegar até a pasta raiz do projeto e executar:

```bash
dotnet build -C Release
```
- navegue até a pasta de output:
```bash
cd bin\Debug\net6.0
mkdir src
touch appsettings.Development.json
```
* Abra `appsettings.Development.json` com um editor de texto e crie o conteúdo abaixo editando os valores de "TokenDandara" e "TokenOpenAI":
```json
{
	"Discord": {
		"TokenDandara": "Colocar Token do Bot Aqui"
	},
	"OpenAi": {
		"TokenOpenAI": "Colocar API key da Open AI aqui"
	}
}
```

Execute o bot através clicando em `botDiscord.exe` ou através do comenado 
```bash 
dotnet botDiscord.dll
```
Inicie o bot com o prefixo '!' seguido do comando. 

## Commandos 
 

| Comando                       | Ação                                                                                                     |
| :---------------------------- | :--------------------------------------------------------------------------------------------------------- |
| `!Hello`  | Retorna World! |
| `!dandara texto`  | Retorna o processamento do texto pelo chatGPT |


## Licença

Dandara é licenciado sob [MIT license](LICENSE).