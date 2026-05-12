# Diagramas de Classes – Sistema de Reserva de Salas

> Padrões aplicados: **Factory Method · Singleton · Strategy · Observer · Decorator**

---

## 1. Visão Geral do Sistema

```mermaid
classDiagram
    direction TB

    class SalaFactory {
        <<interface>>
        +criarSala(tipo: String) Sala
    }

    class SalaFactoryImpl {
        +criarSala(tipo: String) Sala
    }

    class Sala {
        <<abstract>>
        -id: String
        -capacidade: int
        -localizacao: String
        +getNome() String
        +getCapacidade() int
    }

    class SalaDecorator {
        <<abstract>>
        #sala: Sala
        +getNome() String
        +getCapacidade() int
    }

    class ArCondicionadoDecorator {
        +getNome() String
    }

    class BebedouroDecorator {
        +getNome() String
    }

    class SalaEstudoIndividual {
        -possuiLocker: boolean
        +getNome() String
    }

    class SalaTrabalhoGrupo {
        -qtdCadeiras: int
        +getNome() String
    }

    class Laboratorio {
        -softwaresInstalados: List~String~
        +getNome() String
    }

    class ReservaRepository {
        <<Singleton>>
        -instance: ReservaRepository
        -reservas: List~Reserva~
        -ReservaRepository()
        +getInstance() ReservaRepository
        +salvar(r: Reserva) void
        +buscarPorSala(salaId: String) List~Reserva~
        +buscarPorUsuario(userId: String) List~Reserva~
        +listarTodas() List~Reserva~
    }

    class Reserva {
        -id: String
        -sala: Sala
        -usuario: Usuario
        -horario: LocalDateTime
        -duracao: int
        -status: StatusReserva
        +confirmar() void
        +cancelar() void
    }

    class Usuario {
        -matricula: String
        -nome: String
        -email: String
        -tipo: TipoUsuario
    }

    class TipoUsuario {
        <<enumeration>>
        ALUNO
        PROFESSOR
        TECNICO
    }

    class StatusReserva {
        <<enumeration>>
        PENDENTE
        CONFIRMADA
        CANCELADA
        EXPIRADA
    }

    SalaFactoryImpl ..|> SalaFactory
    SalaEstudoIndividual --|> Sala
    SalaTrabalhoGrupo --|> Sala
    Laboratorio --|> Sala
    SalaDecorator --|> Sala
    SalaDecorator o-- Sala : wraps
    ArCondicionadoDecorator --|> SalaDecorator
    BebedouroDecorator --|> SalaDecorator
    SalaFactoryImpl ..> Sala : creates
    ReservaRepository "1" o-- "0..*" Reserva
    Reserva --> Sala
    Reserva --> Usuario
    Usuario --> TipoUsuario
    Reserva --> StatusReserva
```

---

## 2. Padrão Factory Method – Criação de Salas

```mermaid
classDiagram
    direction TB

    class SalaFactory {
        <<interface>>
        +criarSala(tipo: String) Sala
    }

    class SalaFactoryImpl {
        +criarSala(tipo: String) Sala
    }

    class Sala {
        <<abstract>>
        -id: String
        -capacidade: int
        -localizacao: String
        -recursos: List~String~
        +getNome() String
        +getCapacidade() int
        +getRecursos() List~String~
    }

    class SalaEstudoIndividual {
        -possuiLocker: boolean
        -nivelSilencio: int
        +getNome() String
    }

    class SalaTrabalhoGrupo {
        -qtdCadeiras: int
        -possuiQuadro: boolean
        +getNome() String
    }

    class Laboratorio {
        -softwaresInstalados: List~String~
        -qtdComputadores: int
        +getNome() String
        +getSoftwares() List~String~
    }

    class SalaVR {
        -equipamentos: List~String~
        +getNome() String
    }

    SalaFactoryImpl ..|> SalaFactory : implementa
    SalaEstudoIndividual --|> Sala : extends
    SalaTrabalhoGrupo --|> Sala : extends
    Laboratorio --|> Sala : extends
    SalaVR --|> Sala : extends
    SalaFactoryImpl ..> Sala : creates
```

---

## 3. Padrão Singleton – Repositório de Reservas

```mermaid
classDiagram
    direction TB

    class ReservaRepository {
        <<Singleton>>
        -instance: ReservaRepository
        -reservas: List~Reserva~
        -salas: List~Sala~
        -ReservaRepository()
        +getInstance() ReservaRepository
        +salvar(r: Reserva) void
        +remover(id: String) boolean
        +buscarPorSala(salaId: String) List~Reserva~
        +buscarPorUsuario(userId: String) List~Reserva~
        +buscarPorHorario(dt: LocalDateTime) List~Reserva~
        +listarSalas() List~Sala~
        +listarTodas() List~Reserva~
    }

    class Reserva {
        -id: String
        -sala: Sala
        -usuario: Usuario
        -horario: LocalDateTime
        -duracao: int
        -status: StatusReserva
    }

    class SalaFactoryImpl {
        +criarSala(tipo: String) Sala
    }

    class ValidadorReserva {
        -politica: PoliticaReserva
        +validar(nova: Reserva) boolean
    }

    ReservaRepository "1" *-- "0..*" Reserva : armazena
    ValidadorReserva ..> ReservaRepository : consulta
    SalaFactoryImpl ..> ReservaRepository : registra sala
```

---

## 4. Padrão Strategy – Política de Reserva

```mermaid
classDiagram
    direction TB

    class PoliticaReserva {
        <<interface>>
        +validar(nova: Reserva, existentes: List~Reserva~) boolean
        +getDescricao() String
    }

    class PrioridadeDocente {
        +validar(nova: Reserva, existentes: List~Reserva~) boolean
        +getDescricao() String
    }

    class PrimeiroAChegar {
        +validar(nova: Reserva, existentes: List~Reserva~) boolean
        +getDescricao() String
    }

    class LimitePorUsuario {
        -limiteHorasDia: int
        +validar(nova: Reserva, existentes: List~Reserva~) boolean
        +getDescricao() String
    }

    class ValidadorReserva {
        -politica: PoliticaReserva
        +setPolitica(p: PoliticaReserva) void
        +validar(nova: Reserva) boolean
        +getPoliticaAtual() String
    }

    PrioridadeDocente ..|> PoliticaReserva : implementa
    PrimeiroAChegar ..|> PoliticaReserva : implementa
    LimitePorUsuario ..|> PoliticaReserva : implementa
    ValidadorReserva o--> PoliticaReserva : usa estratégia
```

---

## 5. Padrão Observer – Notificações

```mermaid
classDiagram
    direction TB

    class EventManager {
        <<Subject>>
        -observers: Map~String, List~ReservaObserver~~
        +subscribe(evento: String, o: ReservaObserver) void
        +unsubscribe(evento: String, o: ReservaObserver) void
        +notify(evento: String, r: Reserva) void
    }

    class ReservaObserver {
        <<interface>>
        +update(evento: String, reserva: Reserva) void
    }

    class NotificacaoEmailObserver {
        -emailService: EmailService
        +update(evento: String, reserva: Reserva) void
    }

    class NotificacaoPushObserver {
        +update(evento: String, reserva: Reserva) void
    }

    class RelatorioServicoObserver {
        -relatorioRepo: RelatorioRepository
        +update(evento: String, reserva: Reserva) void
    }

    class LogAuditoriaObserver {
        +update(evento: String, reserva: Reserva) void
    }

    NotificacaoEmailObserver ..|> ReservaObserver : implementa
    NotificacaoPushObserver ..|> ReservaObserver : implementa
    RelatorioServicoObserver ..|> ReservaObserver : implementa
    LogAuditoriaObserver ..|> ReservaObserver : implementa
    EventManager "1" o-- "0..*" ReservaObserver : notifica
```

---

## 6. Padrão Decorator – Extensão de Recursos das Salas

```mermaid
classDiagram
    direction TB

    class Sala {
        <<abstract>>
        -id: String
        -capacidade: int
        +getNome() String
        +getCapacidade() int
    }

    class SalaDecorator {
        <<abstract>>
        #sala: Sala
        +SalaDecorator(sala: Sala)
        +getNome() String
        +getCapacidade() int
    }

    class ArCondicionadoDecorator {
        +getNome() String
    }

    class BebedouroDecorator {
        +getNome() String
    }

    class ProjetorDecorator {
        +getNome() String
    }

    class AcessibilidadeDecorator {
        +getNome() String
    }

    SalaDecorator --|> Sala : herda tipo
    SalaDecorator o-- Sala : wrapping
    ArCondicionadoDecorator --|> SalaDecorator
    BebedouroDecorator --|> SalaDecorator
    ProjetorDecorator --|> SalaDecorator
    AcessibilidadeDecorator --|> SalaDecorator
```

---

## 7. Integração Completa – Fluxo Principal

```mermaid
classDiagram
    direction TB

    class SistemaReservas {
        -factory: SalaFactory
        -repository: ReservaRepository
        -validador: ValidadorReserva
        -eventManager: EventManager
        +criarReserva(salaId: String, userId: String, horario: LocalDateTime) Reserva
        +cancelarReserva(reservaId: String) void
        +listarSalasDisponiveis(horario: LocalDateTime) List~Sala~
        +alterarPolitica(p: PoliticaReserva) void
    }

    class SalaFactory {
        <<interface>>
        +criarSala(tipo: String) Sala
    }

    class SalaDecorator {
        <<abstract>>
        #sala: Sala
        +getNome() String
    }

    class ReservaRepository {
        <<Singleton>>
        +getInstance() ReservaRepository
        +salvar(r: Reserva) void
        +listarTodas() List~Reserva~
    }

    class ValidadorReserva {
        -politica: PoliticaReserva
        +validar(nova: Reserva) boolean
        +setPolitica(p: PoliticaReserva) void
    }

    class PoliticaReserva {
        <<interface>>
        +validar(nova: Reserva, existentes: List~Reserva~) boolean
    }

    class EventManager {
        <<Subject>>
        +subscribe(evento: String, observer: ReservaObserver) void
        +notify(evento: String, reserva: Reserva) void
    }

    class ReservaObserver {
        <<interface>>
        +update(evento: String, reserva: Reserva) void
    }

    SistemaReservas --> SalaFactory : 1. cria sala base
    SistemaReservas --> SalaDecorator : 2. envolve com decorators
    SistemaReservas --> ValidadorReserva : 3. valida
    SistemaReservas --> ReservaRepository : 4. persiste
    SistemaReservas --> EventManager : 5. dispara eventos
    ValidadorReserva o--> PoliticaReserva : estratégia
    EventManager o--> ReservaObserver : notifica
```