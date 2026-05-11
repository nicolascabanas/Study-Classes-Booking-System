# Projeto: Sistema de Reserva de Salas (POO)

Protótipo funcional para gerenciamento de reservas de espaços universitários (salas de estudo e laboratórios), desenvolvido para a disciplina de **Projeto de Software Orientado a Objetos (2026)**. O foco do projeto é a aplicação prática de padrões de projeto para garantir escalabilidade e código limpo.

### Equipe
* **Nicolas Cabanas** - https://github.com/nicolascabanas
* **João Vitor Moreira Gomes** - https://github.com/jvmgomes

---

### Padrões de Projeto (Design Patterns)
Para atender aos requisitos técnicos, os seguintes padrões foram implementados:

* **Factory Method**: Utilizado para gerenciar a criação de diferentes tipos de salas (Individual, Grupo e Laboratórios) sem acoplar o sistema às classes concretas.
* **Strategy**: Implementa as políticas de detecção de colisão, permitindo alternar dinamicamente entre as regras "Primeiro a Reservar" e "Prioridade Docente".
* **Observer**: Sistema de notificação para alertar usuários e serviços (Log e E-mail) sobre alterações nas reservas em tempo real, integrado diretamente ao repositório.
* **Singleton**: Repositório centralizado de dados em memória com controle de concorrência (*thread-safety*) e despacho automático de eventos.
* **Decorator**: Extensão de funcionalidades para adicionar itens extras às salas, como **Ar Condicionado** e **Bebedouro**, sem modificar as classes base.

### Requisitos Funcionais
* **RF-01**: Consulta de disponibilidade por intervalo de tempo.
* **RF-02**: Gestão completa de reservas (Inclusão, Alteração e Cancelamento).
* **RF-03**: Motor de validação para impedir conflitos de horários.
* **RF-04**: Notificações automáticas para os envolvidos em caso de mudanças.
* **RF-05**: Geração de relatórios diários de ocupação por sala.

### Estrutura do Projeto
- `src/Decorators/`: Implementação dos opcionais de sala (Padrão Decorator).
- `src/Factories/`: Lógica de criação de salas (Padrão Factory Method).
- `src/Repositories/`: Repositório central (Padrão Singleton).
- `src/Observers/`: Sistema de notificações (Padrão Observer).
- `src/Strategies/`: Regras de negócio para colisões (Padrão Strategy).
- `src/Models/`: Entidades base do sistema.
- `docs/`: Documentação complementar e diagramas UML.
