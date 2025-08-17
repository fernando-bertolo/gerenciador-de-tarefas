"use client";

import { useState } from "react";
import { useForm, Controller, SubmitHandler } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import * as z from "zod";
import { Check, Trash } from "lucide-react";

enum Status {
  Pendente = "Pendente",
  EmProgresso = "EmProgresso",
  Concluida = "Concluida",
}

const tarefaSchema = z.object({
  titulo: z.string().min(1, "O título é obrigatório"),
  descricao: z.string().optional(),
  status: z.nativeEnum(Status),
});

type TarefaForm = z.infer<typeof tarefaSchema>;

interface Tarefa extends TarefaForm {
  id: number;
}

export default function Home() {
  const [tarefas, setTarefas] = useState<Tarefa[]>([]);

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

  const adicionarTarefa: SubmitHandler<TarefaForm> = (data) => {
    const novaTarefa: Tarefa = {
      id: Date.now(),
      ...data,
    };
    setTarefas([...tarefas, novaTarefa]);
    reset();
  };

  const removerTarefa = (id: number) => {
    setTarefas(tarefas.filter((tarefa) => tarefa.id !== id));
  };

  const atualizarTarefa = (id: number, dados: Partial<TarefaForm>) => {
    setTarefas(
      tarefas.map((t) => (t.id === id ? { ...t, ...dados } : t))
    );
  };

  return (
    <div className="min-h-screen bg-gray-50 flex items-center justify-center p-4">
      <div className="w-full max-w-md bg-white rounded-2xl shadow-lg p-6">
        <h1 className="text-3xl font-semibold text-center mb-6 text-gray-800">
          Tarefas
        </h1>

        <form
          onSubmit={handleSubmit(adicionarTarefa)}
          className="flex flex-col gap-3 mb-6"
        >
          <input
            {...register("titulo")}
            placeholder="Título"
            className="px-4 py-2 rounded-xl border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-400 transition"
          />
          {errors.titulo && (
            <span className="text-red-500 text-sm">{errors.titulo.message}</span>
          )}

          <input
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
            className="bg-blue-500 text-white px-4 py-2 rounded-xl hover:bg-blue-600 transition"
          >
            Adicionar
          </button>
        </form>

        {/* Lista de tarefas */}
        <ul className="space-y-4">
          {tarefas.map((tarefa) => (
            <li
              key={tarefa.id}
              className="p-4 bg-gray-100 rounded-2xl shadow hover:bg-gray-200 transition flex flex-col gap-2"
            >
              <input
                value={tarefa.titulo}
                onChange={(e) =>
                  atualizarTarefa(tarefa.id, { titulo: e.target.value })
                }
                className="text-lg font-medium px-2 py-1 rounded border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-400"
              />
              <textarea
                value={tarefa.descricao}
                onChange={(e) =>
                  atualizarTarefa(tarefa.id, { descricao: e.target.value })
                }
                className="px-2 py-1 rounded border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-400"
              />
              <div className="flex items-center justify-between">
                <select
                  value={tarefa.status}
                  onChange={(e) =>
                    atualizarTarefa(tarefa.id, { status: e.target.value as Status })
                  }
                  className="px-2 py-1 rounded border border-gray-300 focus:outline-none focus:ring-2 focus:ring-blue-400"
                >
                  {Object.values(Status).map((s) => (
                    <option key={s} value={s}>
                      {s}
                    </option>
                  ))}
                </select>

                <button
                  onClick={() => removerTarefa(tarefa.id)}
                  className="text-red-500 hover:text-red-700 transition"
                >
                  <Trash className="w-5 h-5" />
                </button>
              </div>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
}
