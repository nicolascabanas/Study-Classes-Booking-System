# Projeto: Sistema de Reserva de Salas (POO)

Prot�tipo funcional para gerenciamento de reservas de espa�os universit�rios (salas de estudo e laborat�rios), desenvolvido para a disciplina de **Projeto de Software Orientado a Objetos (2026)**. O foco do projeto � a aplica��o pr�tica de padr�es de projeto para garantir escalabilidade e c�digo limpo.

### Equipe
* **Nicolas Cabanas** - https://github.com/nicolascabanas
* **João Vitor Moreira Gomes** - https://github.com/jvmgomes

---

### Padr�es de Projeto (Design Patterns)
Para atender aos requisitos t�cnicos, os seguintes padr�es foram implementados:

* **Factory Method**: Utilizado para gerenciar a cria��o de diferentes tipos de salas (Individual, Grupo e Laborat�rios) sem acoplar o sistema �s classes concretas.
* **Strategy**: Implementa as pol�ticas de detec��o de colis�o, permitindo alternar dinamicamente entre as regras "Primeiro a Reservar" e "Prioridade Docente".
* **Observer**: Sistema de notifica��o (Push/Pull) para alertar usu�rios e servi�os sobre altera��es ou cancelamentos em tempo real.
* **Singleton**: Reposit�rio centralizado de dados em mem�ria com controle de concorr�ncia (*thread-safety*).
* **Decorator (Opcional)**: Extens�o de funcionalidades para adicionar itens extras �s reservas, como projetores e servi�os de limpeza.

### Requisitos Funcionais
* **RF-01**: Consulta de disponibilidade por intervalo de tempo.
* **RF-02**: Gest�o completa de reservas (Inclus�o, Altera��o e Cancelamento).
* **RF-03**: Motor de valida��o para impedir conflitos de hor�rios.
* **RF-04**: Notifica��es autom�ticas para os envolvidos em caso de mudan�as.
* **RF-05**: Gera��o de relat�rios di�rios de ocupa��o por sala.

### Estrutura do Projeto
- `src/`: C�digo-fonte em C#.
- `docs/`: Documenta��o complementar e diagramas UML.
- `README.md`: Documenta��o principal do reposit�rio.

