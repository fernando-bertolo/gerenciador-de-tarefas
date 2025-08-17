import { TarefaForm } from "@/schemas/tarefaSchema";
import { Status, Tarefa } from "../types/tarefaTypes";

const API_URL = `${process.env.NEXT_PUBLIC_API_URL}/api/tarefa`;

export const tarefaService = {
  getAll: async (): Promise<Tarefa[]> => {
    const res = await fetch(`${API_URL}`);
    const result = await res.json();
    return result.data;
  },

  create: async (nova: TarefaForm) => {
    return fetch(`${API_URL}`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(nova),
    });
  },

  update: async (id: number, dados: TarefaForm) => {
    return fetch(`${API_URL}/${id}`, {
      method: "PUT",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(dados),
    });
  },

  remove: async (id: number) => {
    return fetch(`${API_URL}/${id}`, { method: "DELETE" });
  },

  updateStatus: async ({id, status}: {id: number, status: Status}) => {
    return fetch(`${API_URL}/${id}/status`, {
      method: "PATCH",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ status }),
    });
  }
};
