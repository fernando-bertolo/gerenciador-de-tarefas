"use client";


import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import "./globals.css";
import { ReactQueryDevtools } from "@tanstack/react-query-devtools";
import { Toaster } from "sonner";

const queryClient = new QueryClient();

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="pt-br">
      <QueryClientProvider client={queryClient}>
        <body>
          {children}
          <Toaster />
        </body>
      </QueryClientProvider>
    </html>
  );
}
