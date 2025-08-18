"use client";

import { FormProvider, useForm } from "react-hook-form";
import { SearchFilter } from "./SearchFilter";
import { StatusFilter } from "./StatusFilter";
import { Filter } from "@/types/filterTypes";
import { Status } from "@/types/tarefaTypes";

interface FilterProps {
    filter: Filter;
    onChangeFilter: (filter: Filter) => void;
}


export const Filters = ({
    filter,
    onChangeFilter
}: FilterProps) => {
    
    const methods = useForm<Filter>({
        defaultValues: filter,
    });

    const onSubmit = async (data: Filter) => {
        onChangeFilter(data);
    };

    return (
        <FormProvider {...methods}>
            <form
                onSubmit={methods.handleSubmit(onSubmit)}
                className="flex items-center gap-4 p-4 bg-gray-50 rounded-2xl shadow-sm"
            >
                <SearchFilter name="search" />
                <StatusFilter
                    name="status"
                    options={[
                        { value: Status.Todos, label: "Todos" },
                        { value: Status.Pendente, label: "Pendente" },
                        { value: Status.EmProgresso, label: "Em Progresso" },
                        { value: Status.Concluida, label: "Concluído" },
                    ]}
                />

                <button
                    type="submit"
                    className="rounded-xl bg-gray-900 text-white px-4 py-2 text-sm shadow hover:bg-gray-800 transition"
                >
                    Aplicar
                </button>
            </form>
        </FormProvider>
    );
}
