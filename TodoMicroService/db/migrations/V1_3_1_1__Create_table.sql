CREATE TABLE IF NOT EXISTS public.todo (
id SERIAL PRIMARY KEY,                        -- Identificador autoincremental
title VARCHAR(200) NOT NULL,                  -- Título o descripción corta
description TEXT,                             -- Detalle opcional
is_completed BOOLEAN NOT NULL DEFAULT FALSE,  -- Estado de la tarea
created_at TIMESTAMP NOT NULL DEFAULT NOW(),  -- Fecha de creación
updated_at TIMESTAMP                          -- Fecha de última actualización
);