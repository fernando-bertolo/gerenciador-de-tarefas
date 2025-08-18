"use client";
import { useForm, Controller } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { tarefaSchema, TarefaForm } from "../schemas/tarefaSchema";
import { Status } from "../types/tarefaTypes";
import { X } from "lucide-react";
import { useEffect } from "react";

interface Props {
  defaultValues?: TarefaForm;
  onSubmit: (data: TarefaForm) => void;
  onClose: () => void;
}

export function TarefaModal({ defaultValues, onSubmit, onClose }: Props) {
  const { register, handleSubmit, control, formState: { errors }, reset } = useForm<TarefaForm>({
    resolver: zodResolver(tarefaSchema),
    defaultValues: defaultValues ?? { titulo: "", descricao: "", status: Status.Pendente },
  });

  useEffect(() => {
    if(defaultValues) {
      reset(defaultValues);
    }
  }, [defaultValues, reset])

  return (
    <div className="fixed inset-0 bg-black/40 flex items-center justify-center">
      <div className="bg-white p-6 rounded-xl w-full max-w-md relative">
        <button onClick={onClose} className="absolute top-4 right-4 text-gray-500">
          <X className="w-5 h-5" />
        </button>

        <h2 className="text-xl font-semibold mb-4">
          {defaultValues ? "Editar Tarefa" : "Nova Tarefa"}
        </h2>

        <form onSubmit={handleSubmit(onSubmit)} className="flex flex-col gap-4">
          <input {...register("titulo")} placeholder="Título" className="border rounded p-2" />
          {errors.titulo && <span className="text-red-500">{errors.titulo.message}</span>}

          <textarea {...register("descricao")} placeholder="Descrição" className="border rounded p-2" />
          {errors.descricao && <span className="text-red-500">{errors.descricao.message}</span>}

          <Controller
            name="status"
            control={control}
            render={({ field }) => (
              <select {...field} className="border rounded p-2">
                <option value="Pendente">Pendente</option>
                <option value="EmProgresso">Em Progresso</option>
                <option value="Concluida">Concluída</option>
              </select>
            )}
          />

          <button type="submit" className="bg-blue-600 text-white p-2 rounded cursor-pointer hover:bg-blue-500">
            {defaultValues ? "Salvar Alterações" : "Adicionar"}
          </button>
        </form>
      </div>
    </div>
  );
}
