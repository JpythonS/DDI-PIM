# Diagrama de Implantação

## Componentes do Sistema

_**1. Servidores WEB**_ 
- Serão incluídos dois servidores WEB para garantir alta disponibilidade e balanceamento de carga, hospendando a versão WEB da aplicação de folha de pagamento;
- Os servidores WEB serão configurados para executar o software da aplicação e lidar com as solicitações dos usuários.

_**2. Servidor de Aplicação**_
- Será incluído um servidor de aplicação que suporte a lógica de negócios da aplicação e fornece serviços para ambas as plataformas (WEB e Desktop).

_**3. Banco de Dados**_ 
- Utilizaremos um servidor de banco de dados (SQL SERVER) para armazenar todos os dados relacionados aos funcionários e a folha de pagamento, incluindo informações de funcionário, registros de pagamento, configurações do sistema, etc.

_**4. Aplicação WEB**_
- A aplicação WEB será acessada por meio de navegadores, como Chrome, Firefox ou Edge;
- Os servidores WEB fornecerão a interface de usuário e vão interagir com o servidor de aplicação para processar as solicitações dos usuários.

_**5. Aplicação DESKTOP**_
- A versão DESKTOP será instalada em computadores de usuários ADMIN e Recursos Humanos;
- Os computadores dos usuários se comunicarão com o servidor de aplicação para obter dados e funcionalidades.

## Instalação do Sistema

_**1. Instalação da Aplicação WEB**_
- A aplicação WEB já estará implantada nos servidores WEB, portanto os usuários poderão acessá-la apenas abrindo um navegador e digitando a URL do sistema.

_**2. Instalação da Aplicação DESKTOP**_
- Para instalar a aplicação DESKTOP nos computadores será criado um instalador adequado para a plataforma, no caso um .exe para Windows;
- Os usuários poderão baixar e executar o instalador em seus computadores para instalar a aplicação;
- Durante a instalação, os usuários podem ser solicitados a inserir informações de conexão, como o endereço do servidor de aplicação e as credenciais;
- Após finalizar a instalação será necessário incluir o nome de usuário e a senha pré-definidas.

_**3. Configuração do Banco de Dados**_
- O servidor de banco de dados será configurado de acordo com todas as tabelas e estruturas de dados necessárias criadas;
- Os dados críticos, como informações de funcionários e configurações do sistema, serão importados ou inseridos manualmente no banco de dados, de acordo com a necessidade.

_**4. Teste e Treinamento**_
- Serão realizados testes extensivos em ambas as plataformas para garantir que a aplicação funcione conforme o esperado;
- Será fornecido treinamento presencial aos usuários ADMIN e RH, os quais repassarão aos funcionários gerais juntamente com o manual do sistema impresso ou em PDF, para garantir que todos saibam usar as aplicações.

_**5. Manutenção Contínua**_
- Será implementado um plano de manutenção contínua para atualizações de software, correções de segurança e backup regular dos dados em ambos os servidores de aplicação e banco de dados.
