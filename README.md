# ⚡ PowerGuard - Sistema de Gerenciamento de Falhas de Energia e Impactos Cibernéticos

## 📖 Finalidade do Sistema

O **PowerGuard** é um sistema para **registro, gerenciamento e monitoramento de falhas de energia**, com foco em seus **impactos cibernéticos**.

Visa apoiar **equipes de infraestrutura e segurança da informação** na rápida identificação de falhas elétricas, avaliação de riscos cibernéticos associados e acompanhamento das ações corretivas.

O sistema fortalece a **resiliência cibernética** organizacional, reduzindo riscos e tempo de resposta frente a incidentes que afetam sistemas críticos.

---

## 🚀 Funcionalidades

- **Registrar falha de energia**: Adicione uma nova ocorrência com local, início, previsão e impacto.
- **Listar falhas**: Veja todas as falhas registradas com detalhes.
- **Alterar falha**: Edite informações de uma falha existente.
- **Excluir falha**: Remova uma falha do sistema permanentemente.
- **Gerar relatório**: Resumo com total de falhas, quantidade de resolvidas e em aberto.

## 🔑 Acesso ao Sistema
Durante o uso, o sistema solicitará autenticação. Use as seguintes credenciais de teste:

Usuário: admin

Senha: 1234

(Essas credenciais podem ser ajustadas no código, conforme necessidade.)

## 💡 Exemplo de Uso
Após iniciar, escolha uma das opções no menu:

1 - Registrar falha

2 - Listar falhas

3 - Alterar falha

4 - Excluir falha

5 - Gerar relatório

0 - Sair

## 📦 Dependências

O PowerGuard utiliza as seguintes bibliotecas e tecnologias:
- **.NET 6 (ou superior)**: Plataforma para desenvolvimento da aplicação console.
- **Console Application**: Interação via linha de comando para usuário final.
- **IDE recomendado**: Visual Studio ou Visual Studio Code com extensão C#.

## 🗂️ Estrutura de Pastas

```plaintext
PowerGuard/
├── Model/
│   ├── Falha.cs               
│   └── FalhaEnergia.cs                
├── Service/
│   ├── LoginService.cs         
│   └── FalhaService.cs          
├── Controller/
│   ├── FalhaController.cs      
│   └── LoginController.cs       
├── View/          
│   ├── MenuView.cs            
│   └── LoginView.cs            
├── Program.cs                  
├── PowerGuard.csproj             
└── README.md                   
```


