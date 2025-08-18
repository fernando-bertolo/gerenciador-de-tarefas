import * as z from "zod";
import { Status } from "../types/tarefaTypes";

export const tarefaSchema = z.object({
  titulo: z.string().min(1, "O título é obrigatório"),
  descricao: z.string().max(500, "A descrição não pode ter mais de 500 caracteres").optional(),
  status: z.nativeEnum(Status),
  dataConclusao: z.string().optional(),
});

export type TarefaForm = z.infer<typeof tarefaSchema>;
