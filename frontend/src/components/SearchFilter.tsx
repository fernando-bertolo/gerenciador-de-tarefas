"use client";

import { useFormContext } from "react-hook-form";
import { Search } from "lucide-react";

interface Props {
  name: string;
  placeholder?: string;
}

export function SearchFilter({ name, placeholder = "Pesquisar..." }: Props) {
  const { register } = useFormContext();

  return (
    <div className="relative w-full max-w-sm">
      <Search className="absolute left-3 top-1/2 -translate-y-1/2 h-4 w-4 text-gray-400" />
      <input
        type="text"
        {...register(name)}
        placeholder={placeholder}
        className="w-full rounded-xl border border-gray-300 bg-white pl-10 pr-3 py-2 text-sm shadow-sm focus:border-gray-400 focus:ring-2 focus:ring-gray-200 outline-none transition"
      />
    </div>
  );
}
