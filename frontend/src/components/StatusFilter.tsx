"use client";

import { useFormContext } from "react-hook-form";

interface Props {
  name: string;
  options: { value: string; label: string }[];
}

export function StatusFilter({ name, options }: Props) {
  const { register } = useFormContext();

  return (
    <select
      {...register(name)}
      className="rounded-xl border border-gray-300 bg-white px-3 py-2 text-sm shadow-sm focus:border-gray-400 focus:ring-2 focus:ring-gray-200 outline-none transition"
    >
      {options.map((opt) => (
        <option key={opt.value} value={opt.value}>
          {opt.label}
        </option>
      ))}
    </select>
  );
}
