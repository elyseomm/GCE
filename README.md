# GCE
Sistema de Gestão de Compras

## Pré-requisitos Ambiente Dev:
- Instalar o Visual Studio 2019 no mínimo.
- Baixar o projéto no github: https://github.com/elyseomm/GCE.git

- Instancia do SQL Server(versão 16 de preferência).
- Crie um Database no SQL Server com o nome 'GCEMesquita'.

- Com o VS Instalado e o Projeto GCE baixado em uma pasta de trabalho:
- Vá para a pasta '..\GCE\CGEWebApp';
- Abra a Solution 'CGEWebApp.sln';
- Certifique-se de que todos os pacotes e dependencias foram instaladas corretamente;
- Depois acesse a opção de menu 'Tools', 'NuGet Package Manager' e em seguida 'Package Manager Console';
- Vamos rodar o 'Migration' para inicializar o Banco de Dados 'GCEMesquita'.

- No prompt de comando do 'Package Manager Console' na guia 'Default Project' selecione o projeto 'CGE.Core' na caixa de seleção;

- No prompt de comando do 'Package Manager Console' digite 'add-migrations SetupInicial':
    
    Ex: 
    - PM> add-migrations SetupInicial + <ENTER>, aguarde o término do processo;

        - deverá surgir a pasta 'Migrations' com dois aquivos no projetoi CGE.Core:

            - YYYYMMDDHHMMSSTT_SetupInicial.cs
            - CGEContextModelSnapshot.cs;
    
    - Depois digite 'update-database':
    Ex:
    - PM> update-database, aguarde o término do processo;

- Neste momento, após rodar o Migration, a tabela Supplier deve ter sido criada no Banco de Dados 'CGEMesquita', já com alguns fornecedores cadastrados;


--------------------------------------------------------------------------------------------------------------------------------------------
- RODANDO A APLICAÇÂO
--------------------------------------------------------------------------------------------------------------------------------------------

- A Aplicação se divide em duas partes(Back-End / Front-End), para que tudo funcione precisamos rodas as duas separadamente:

BACK-END:
------------------------------------------------------------------
- Para rodar o Back-End em Dev marque o projeto 'CGE.Api' como 'Projeto Inicial' = 'StartUp Project':
    - para isso clique com o botão direito no projeto 'CGE.Api' e escolha a opção 'Set as StartUp Project' e estamos prontos pra rodar.
    - F5 e pãhhh.

    - Em minha máquina o endereço do back-end foi:  https://localhost:44306
    
    - Para a listagem do Swagger:                   https://localhost:44306/swagger/index.html

-(Se desejar instalar numa instância do IIS é só publicar o projeto 'CGE.Api' numa instância do IIS na rede).


FRONT-END:
------------------------------------------------------------------
- Para rodar o Front-End em Dev precisamos abrir uma nova instancia do Visual Studio( Caso o back-end já esteja rodando noutro VS local)
- Vá para a pasta '..\GCE\CGEWebApp' e abra a Solution 'CGEWebApp.sln' novamente;

E então marque o projeto 'CGEWebApp' como 'Projeto Inicial' = 'StartUp Project':
    - para isso clique com o botão direito no projeto 'CGEWebApp' e escolha a opção 'Set as StartUp Project' e estamos prontos pra rodar.

IMPORTANTE: Precisamos configurar o FRONT-END com o endereço(URL) da 'CGE.Api' no : 
    
    Ex: https://localhost:44306

    - Para isto altere o arquivo 'Web.config' dentro de 'appSettings' na chave(Key) 'APIUrl', em valor coloque o endereço do back-end: 
    Ex: 
        <add key="ApiUrl" value="https://localhost:44306" />

    Assim como as demais rotas da Api para as diferentes operações:

        <add key="SupplierList" value="suppliers" />
        <add key="Supplier" value="suppliers" />
        <add key="NewPF" value="suppliers/newpf" />
        <add key="NewPJ" value="suppliers/newpj" />
        <add key="Ativar" value="suppliers/ativar" />
        <add key="Desativar" value="suppliers/desativar" />
        <add key="UpdatePF" value="suppliers/updatepf" />
        <add key="UpdatePJ" value="suppliers/updatepj" />
        <add key="Delete" value="suppliers/delete" />

    Pronto o front já sabe onde consultar os dados na API.

    
- F5 e agora podemos rodar o sistema.

- Em minha máquina o endereço do front-end foi:  https://localhost:44305/ na outra porta '44305'.