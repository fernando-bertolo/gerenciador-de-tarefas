import { TarefaForm } from "@/schemas/tarefaSchema";
import { Status, Tarefa } from "../types/tarefaTypes";
import { Filter } from "@/types/filterTypes";
import { toast } from "sonner";

const API_URL = `${process.env.NEXT_PUBLIC_API_URL}/api/v1/tarefa`;

export const tarefaService = {
  getAll: async (data: Filter): Promise<Tarefa[]> => {
    try {
      const url = `${API_URL}?search=${data.search}&status=${data.status}`;
      const res = await fetch(url);
      const result = await res.json();

      if (!res.ok) {
        toast.error(result?.error || "Erro ao buscar tarefas");
        return [];
      }

      return result.data;
    } catch (error) {
      toast.error("Erro de conexão ao buscar tarefas");
      return [];
    }
  },

  create: async (nova: TarefaForm) => {
    try {
      const res = await fetch(`${API_URL}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(nova),
      });
      const result = await res.json();

      if (!res.ok) {
        const msg = result?.errors
          ? Object.values(result.errors).flat().join(", ")
          : result?.error || "Erro ao criar tarefa";
        toast.error(msg);
        return;
      }

      toast.success("Tarefa criada com sucesso!");
      return result;
    } catch (error) {
      toast.error("Erro de conexão ao criar tarefa");
    }
  },

  update: async (id: number, dados: TarefaForm) => {
    try {
      const res = await fetch(`${API_URL}/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(dados),
      });
      const result = await res.json();

      if (!res.ok) {
        toast.error(result?.error || "Erro ao atualizar tarefa");
        return;
      }

      toast.success("Tarefa atualizada com sucesso!");
      return result;
    } catch (error) {
      toast.error("Erro de conexão ao atualizar tarefa");
    }
  },

  remove: async (id: number) => {
    try {
      const res = await fetch(`${API_URL}/${id}`, { method: "DELETE" });

      if (!res.ok) {
        const result = await res.json();
        toast.error(result?.error || "Erro ao deletar tarefa");
        return;
      }

      toast.success("Tarefa deletada com sucesso!");
    } catch (error) {
      toast.error("Erro de conexão ao deletar tarefa");
    }
  },

  updateStatus: async ({id, status}: {id: number, status: Status}) => {
    try {
      const res = await fetch(`${API_URL}/${id}/status`, {
        method: "PATCH",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ status }),
      });
      const result = await res.json();

      if (!res.ok) {
        toast.error(result?.error || "Erro ao atualizar status");
        return;
      }

      toast.success("Status atualizado com sucesso!");
      return result;
    } catch (error) {
      toast.error("Erro de conexão ao atualizar status");
    }
  }
};
