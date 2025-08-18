"use client";
import { useState } from "react";
import { useTarefas } from "../hooks/useTarefas";
import { Status, Tarefa } from "../types/tarefaTypes";
import { TarefaModal } from "../components/TarefaModal";
import { Check, Trash, Plus, Edit, Inbox } from "lucide-react";
import { TarefaForm, tarefaSchema } from "@/schemas/tarefaSchema";
import { Controller, useForm } from "react-hook-form";
import { Filters } from "@/components/Filters";
import { Filter } from "@/types/filterTypes";

export default function Home() {
  const [filter, setFilter] = useState<Filter>({search: "", status: Status.Todos});

  const { tarefas, addTarefa, editTarefa, deleteTarefa, updateStatusTarefa } = useTarefas(filter);
  const [modalOpen, setModalOpen] = useState(false);
  const [editData, setEditData] = useState<Tarefa | null>(null);

  const { control } = useForm<TarefaForm>();

  const handleSave = (data: TarefaForm) => {
    console.log(data);
    if (editData) {
      editTarefa.mutate({ id: editData.codigo, dados: data });
    } else {
      addTarefa.mutate(data);
    }
    setModalOpen(false);
    setEditData(null);
  };

  return (
    <div className="p-6 flex flex-col items-center">
      <h1 className="text-3xl font-bold mb-4">Tarefas</h1>

      <button
        onClick={() => { setModalOpen(true); setEditData(null); }}
        className="bg-blue-600 text-white px-4 py-2 rounded-full flex items-center gap-2 mb-6"
      >
        <Plus className="w-5 h-5" /> Nova Tarefa
      </button>

      <div className="w-full max-w-2xl grid gap-4">
        <Filters filter={filter} onChangeFilter={setFilter} />

        <ul className="flex flex-col gap-4 max-h-30">
          { tarefas.length > 0 ? tarefas.map(tarefa => (
            <li 
              key={tarefa.codigo} 
              className={`bg-white p-4 rounded-xl shadow flex justify-between items-start border-l-4 ${
                tarefa.status === "Concluida" ? "border-green-500" : 
                tarefa.status === "EmProgresso" ? "border-blue-500" : 
                "border-gray-200"
              }`}
            >
              <div>
                <p className="font-semibold">{tarefa.titulo}</p>
                {tarefa.descricao && (
                  <p className="text-sm text-gray-500">{tarefa.descricao}</p>
                )}

                {tarefa.status === "Concluida" ? (
                  <p className="text-xs bg-green-100 text-green-800 rounded-full px-2 py-1 w-max mt-2">
                    {tarefa.dataConclusao 
                      ? `Concluído em: ${tarefa.dataConclusao}` 
                      : "Concluído"}
                  </p>
                ) : (
                  <Controller
                    name="status"
                    control={control}
                    render={({ field }) => (
                      <select 
                        {...field} 
                        value={tarefa.status}
                        className="border rounded p-2 text-sm mt-2"
                        onChange={(e) => {
                          field.onChange(e.target.value as Status);
                          updateStatusTarefa.mutate({ id: tarefa.codigo, status: e.target.value as Status });
                        }}
                      >
                        <option value="Pendente">Pendente</option>
                        <option value="EmProgresso">Em Progresso</option>
                        <option value="Concluida">Concluída</option>
                      </select>
                    )}
                  />
                )}
              </div>

              <div className="flex gap-3">
                <button 
                  onClick={() => { setEditData(tarefa); setModalOpen(true); }} 
                  className="text-green-600 hover:text-green-800"
                >
                  <Edit />
                </button>
                <button 
                  onClick={() => deleteTarefa.mutate(tarefa.codigo)} 
                  className="text-red-600 hover:text-red-800"
                >
                  <Trash />
                </button>
              </div>
            </li>
          )) : (
            <div className="flex flex-col items-center justify-center py-16 text-center">
              <div className="rounded-2xl bg-gray-100 p-6 shadow-sm">
                <Inbox className="h-12 w-12 text-gray-400" />
              </div>
              <h2 className="mt-6 text-lg font-semibold text-gray-700">
                Nenhum registro encontrado
              </h2>
              <p className="mt-2 text-sm text-gray-500 max-w-sm">
                Parece que você ainda não possui registros cadastrados.  
                Quando houver, eles aparecerão aqui.
              </p>
            </div>
          )}
        </ul>
      </div>


      {modalOpen && (
        <TarefaModal
          defaultValues={editData ?? undefined}
          onSubmit={handleSave}
          onClose={() => setModalOpen(false)}
        />
      )}
    </div>
  );
}
