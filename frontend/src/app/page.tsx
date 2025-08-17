"use client";

import { useState } from "react";
import { useForm, Controller, SubmitHandler } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import * as z from "zod";
import { Check, Trash, Plus, X } from "lucide-react";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";

enum Status {
  Pendente = "Pendente",
  EmProgresso = "EmProgresso",
  Concluida = "Concluida",
}

const tarefaSchema = z.object({
  titulo: z.string().min(1, "O título é obrigatório"),
  descricao: z.string().optional(),
  status: z.nativeEnum(Status),
  dataConclusao: z.string().optional(),
});

type TarefaForm = z.infer<typeof tarefaSchema>;

interface Tarefa extends TarefaForm {
  codigo: number;
}

export default function Home() {
  const queryClient = useQueryClient();
  const [modalOpen, setModalOpen] = useState(false);
  const [editTarefa, setEditTarefa] = useState<Tarefa | null>(null);

  const {
    register,
    handleSubmit,
    reset,
    control,
    formState: { errors },
  } = useForm<TarefaForm>({
    resolver: zodResolver(tarefaSchema),
    defaultValues: {
      titulo: "",
      descricao: "",
      status: Status.Pendente,
    },
  });

  const { data: tarefas = [] } = useQuery<Tarefa[]>({
    queryKey: ["tarefas"],
    queryFn: async () => {
      const res = await fetch("http://localhost:5228/api/tarefa");
      const result = await res.json();
      return result.data;
    },
  });

  const addMutation = useMutation({
    mutationFn: (nova: TarefaForm) =>
      fetch("http://localhost:5228/api/tarefa", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(nova),
      }),
    onSuccess: () => {
      queryClient.invalidateQueries(["tarefas"]);
      setModalOpen(false);
      reset();
    },
  });

  const editMutation = useMutation({
    mutationFn: ({ id, dados }: { id: number; dados: Partial<TarefaForm> }) =>
      fetch(`http://localhost:5228/api/tarefa/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(dados),
      }),
    onSuccess: () => {
      queryClient.invalidateQueries(["tarefas"]);
      setModalOpen(false);
      setEditTarefa(null);
    },
  });

  const deleteMutation = useMutation({
    mutationFn: ({ id }: { id: number }) =>
      fetch(`http://localhost:5228/api/tarefa/${id}`, {
        method: "DELETE",
        headers: { "Content-Type": "application/json" },
      }),
    onSuccess: () => {
      queryClient.invalidateQueries(["tarefas"]);
      setModalOpen(false);
      setEditTarefa(null);
    },
  });

  const onSubmit: SubmitHandler<TarefaForm> = (data) => {
    if (editTarefa) {
      editMutation.mutate({ id: editTarefa.codigo, dados: data });
    } else {
      addMutation.mutate(data);
    }
  };

  const openEditModal = (tarefa: Tarefa) => {
    setEditTarefa(tarefa);
    reset(tarefa);
    setModalOpen(true);
  };

  const openAddModal = () => {
    setEditTarefa(null);
    reset();
    setModalOpen(true);
  };

  return (
    <div className="min-h-screen bg-gray-50 flex flex-col items-center p-6">
      <h1 className="text-4xl font-bold mb-6 text-gray-800">Tarefas</h1>

      <button
        onClick={openAddModal}
        className="flex items-center gap-2 bg-blue-600 text-white px-5 py-3 rounded-full shadow hover:bg-blue-700 transition mb-6"
      >
        <Plus className="w-5 h-5" /> Nova Tarefa
      </button>

      <ul className="w-full max-w-2xl grid grid-cols-1 gap-4">
        {tarefas.map((tarefa, index) => (
          <li
            key={index}
            className="bg-white p-4 rounded-xl shadow hover:shadow-md transition flex justify-between items-center"
          >
            <div className="flex flex-col">
              <span className="text-lg font-semibold">{tarefa.titulo}</span>
              {tarefa.descricao && (
                <span className="text-gray-500 text-sm mt-1">{tarefa.descricao}</span>
              )}

              {tarefa.dataConclusao ? (
                <span className="text-xs mt-1 px-2 py-1 bg-gray-200 rounded-full w-max">
                  Concluído em: {tarefa.dataConclusao}
                </span>
              ) : (
                <span className="text-xs mt-1 px-2 py-1 bg-gray-200 rounded-full w-max">
                  {tarefa.status}
                </span>
              )}
            </div>

            <div className="flex gap-3">
              <button
                onClick={() => openEditModal(tarefa)}
                className="text-green-500 hover:text-green-700 transition"
              >
                <Check className="w-5 h-5" />
              </button>
              <button
                onClick={() =>
                  deleteMutation.mutate({ id: tarefa.codigo })
                }
                className="text-red-500 hover:text-red-700 transition"
              >
                <Trash className="w-5 h-5" />
              </button>
            </div>
          </li>
        ))}
      </ul>

      {/* Modal */}
      {modalOpen && (
        <div className="backdrop-blur-xs backdrop-grayscale backdrop-brightness-80 fixed inset-0 z-50 flex items-center justify-center">
          <div className="bg-white rounded-2xl w-full max-w-md p-6 relative">
            <button
              onClick={() => setModalOpen(false)}
              className="absolute top-4 right-4 text-gray-500 hover:text-gray-800 transition"
            >
              <X className="w-5 h-5" />
            </button>

            <h2 className="text-2xl font-semibold mb-4">
              {editTarefa ? "Editar Tarefa" : "Nova Tarefa"}
            </h2>

            <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col gap-4">
              <input
                {...register("titulo")}
                placeholder="Título"
                className="px-4 py-2 rounded-xl border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-400 transition"
              />
              {errors.titulo && (
                <span className="text-red-500 text-sm">{errors.titulo.message}</span>
              )}

              <textarea
                {...register("descricao")}
                placeholder="Descrição (opcional)"
                className="px-4 py-2 rounded-xl border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-400 transition"
              />

              <Controller
                control={control}
                name="status"
                render={({ field }) => (
                  <select
                    {...field}
                    className="px-4 py-2 rounded-xl border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-400 transition"
                  >
                    {Object.values(Status).map((s) => (
                      <option key={s} value={s}>
                        {s}
                      </option>
                    ))}
                  </select>
                )}
              />

              <button
                type="submit"
                className="bg-blue-600 text-white px-4 py-2 rounded-xl hover:bg-blue-700 transition"
              >
                {editTarefa ? "Salvar Alterações" : "Adicionar Tarefa"}
              </button>
            </form>
          </div>
        </div>
      )}
    </div>
  );
}
