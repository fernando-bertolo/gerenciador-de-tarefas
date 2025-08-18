import { useQuery, useMutation, useQueryClient } from "@tanstack/react-query";
import { tarefaService } from "../services/tarefaService";
import { Status, Tarefa } from "../types/tarefaTypes";
import { TarefaForm } from "@/schemas/tarefaSchema";
import { Filter } from "@/types/filterTypes";

export function useTarefas(filter?: Filter) {
  const queryClient = useQueryClient();

  const { data: tarefas = [] } = useQuery<Tarefa[]>({
    queryKey: ["tarefas", filter],
    queryFn: () => tarefaService.getAll(filter || {search: "", status: Status.Todos}),
  });

  const addTarefa = useMutation({
    mutationFn: tarefaService.create,
    onSuccess: () => queryClient.invalidateQueries(["tarefas"]),
  });

  const editTarefa = useMutation({
    mutationFn: ({ id, dados }: { id: number; dados: TarefaForm }) =>
    tarefaService.update(id, dados),
    onSuccess: () => queryClient.invalidateQueries(["tarefas"]),
  });

  const deleteTarefa = useMutation({
    mutationFn: (id: number) => tarefaService.remove(id),
    onSuccess: () => queryClient.invalidateQueries(["tarefas"]),
  });

  const updateStatusTarefa = useMutation({
    mutationFn: ({id, status}: {id: number, status: Status}) => tarefaService.updateStatus({id, status}),
    onSuccess: () => queryClient.invalidateQueries(["tarefas"]),
  })

  return { tarefas, addTarefa, editTarefa, deleteTarefa, updateStatusTarefa };
}
