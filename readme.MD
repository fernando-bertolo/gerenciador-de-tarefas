# Gerenciador de Tarefas

Um sistema de **gerenciamento de tarefas** com **frontend em Next.js** e **backend em C# com .NET 9**, utilizando **Clean Architecture** e **PostgreSQL**, rodando tudo em **Docker**.

---

## 🏗️ Tecnologias

### Frontend
- **Next.js 14+**
- **Node.js 24**
- **TypeScript**
- **React Hook Form** (gerenciamento de formulários)
- **Zod** (validação de dados)
- **React Query** (gerenciamento de estado e dados assíncronos)
- **shadcn/ui** (componentes UI)

### Backend
- **C#**
- **.NET 9**
- **Clean Architecture**
- **Entity Framework Core**
- **PostgreSQL**

### DevOps
- **Docker** (containers para frontend, backend e banco)
- **Docker Compose**

---

## 📦 Estrutura do Projeto

gerenciador-de-tarefas/
│
├─ backend/ # Backend C# .NET
│ ├─ src/
│ ├─ Dockerfile
│ └─ ...
│
├─ frontend/ # Frontend Next.js
│ ├─ src/
│ ├─ Dockerfile
│ └─ ...
│
├─ docker-compose.yml

---

## 🚀 Rodando o Projeto

### Pré-requisitos
- Docker
- Docker Compose

### Passos

1. Clonar o repositório:

```bash
git clone https://github.com/fernando-bertolo/gerenciador-de-tarefas
cd gerenciador-de-tarefas
```

2. Construir e iniciar os containers

```bash
docker compose up --build -d
```

3. Acessar o frontend

```bash
http://localhost:3000
```

4. Acessar o backend

```bash
http://localhost:5228
```

## ⚡ Funcionalidades

- Listar tarefas
- Criar/editar tarefas com validação
- Filtrar por status
- Clean Architecture no backend para maior escalabilidade
- Persistência em PostgreSQL
- APIs documentadas e prontas para integração


## Documentação Swagger

- Acesse http://localhost:5228/