# Projeto: Sistema de Reserva de Salas (POO)

Protótipo funcional para gerenciamento de reservas de espaços universitários (salas de estudo e laboratórios), desenvolvido para a disciplina de **Projeto de Software Orientado a Objetos (2026)**. O foco do projeto é a aplicação prática de padrões de projeto para garantir escalabilidade e código limpo.

### Equipe
* **Nicolas Cabanas** - [Link do GitHub]
* **[Nome do Integrante 2]** - [Link do GitHub]

---

### Padrões de Projeto (Design Patterns)
Para atender aos requisitos técnicos, os seguintes padrões foram implementados:

* **Factory Method**: Utilizado para gerenciar a criação de diferentes tipos de salas (Individual, Grupo e Laboratórios) sem acoplar o sistema às classes concretas.
* **Strategy**: Implementa as políticas de detecção de colisão, permitindo alternar dinamicamente entre as regras "Primeiro a Reservar" e "Prioridade Docente".
* **Observer**: Sistema de notificação (Push/Pull) para alertar usuários e serviços sobre alterações ou cancelamentos em tempo real.
* **Singleton**: Repositório centralizado de dados em memória com controle de concorrência (*thread-safety*).
* **Decorator (Opcional)**: Extensão de funcionalidades para adicionar itens extras às reservas, como projetores e serviços de limpeza.

### Requisitos Funcionais
* **RF-01**: Consulta de disponibilidade por intervalo de tempo.
* **RF-02**: Gestão completa de reservas (Inclusão, Alteração e Cancelamento).
* **RF-03**: Motor de validação para impedir conflitos de horários.
* **RF-04**: Notificações automáticas para os envolvidos em caso de mudanças.
* **RF-05**: Geração de relatórios diários de ocupação por sala.

### Estrutura do Projeto
- `src/`: Código-fonte em C#.
- `docs/`: Documentação complementar e diagramas UML.
- `README.md`: Documentação principal do repositório.

