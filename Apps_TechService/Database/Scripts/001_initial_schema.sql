-- TechService / PostgreSQL 16+
-- Base de datos objetivo: techservice_dev
-- Ejecutar con psql conectado a la base de datos objetivo.

BEGIN;

CREATE TABLE roles (
    role_id SMALLINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    role_name VARCHAR(50) NOT NULL UNIQUE,
    description VARCHAR(200),
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE service_statuses (
    status_id SMALLINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    status_name VARCHAR(50) NOT NULL UNIQUE,
    description VARCHAR(200),
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE maintenance_types (
    maintenance_type_id SMALLINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    type_name VARCHAR(50) NOT NULL UNIQUE,
    description VARCHAR(200),
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE device_types (
    device_type_id SMALLINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    type_name VARCHAR(50) NOT NULL UNIQUE,
    description VARCHAR(200),
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE individuals (
    individual_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    identification_number VARCHAR(30) NOT NULL UNIQUE,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE,
    phone VARCHAR(30),
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE customers (
    customer_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    individual_id BIGINT NOT NULL UNIQUE REFERENCES individuals(individual_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    address VARCHAR(250),
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE technicians (
    technician_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    individual_id BIGINT NOT NULL UNIQUE REFERENCES individuals(individual_id) ON UPDATE CASCADE ON DELETE CASCADE,
    specialty VARCHAR(100) NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE system_accounts (
    account_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(256) NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    last_login_at TIMESTAMPTZ
);

CREATE TABLE account_roles (
    account_role_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    account_id BIGINT NOT NULL UNIQUE REFERENCES system_accounts(account_id) ON UPDATE CASCADE ON DELETE CASCADE,
    individual_id BIGINT NOT NULL REFERENCES individuals(individual_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    role_id SMALLINT NOT NULL REFERENCES roles(role_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    assigned_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    UNIQUE (individual_id, role_id)
);

CREATE TABLE devices (
    device_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    device_code VARCHAR(30) NOT NULL UNIQUE,
    customer_id BIGINT NOT NULL REFERENCES customers(customer_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    device_type_id SMALLINT NOT NULL REFERENCES device_types(device_type_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    brand VARCHAR(100) NOT NULL,
    model VARCHAR(100) NOT NULL,
    serial_number VARCHAR(100) NOT NULL,
    reported_problem TEXT NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE device_receipts (
    receipt_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    device_id BIGINT NOT NULL REFERENCES devices(device_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    received_by_account_id BIGINT NOT NULL REFERENCES system_accounts(account_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    receipt_date TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    physical_condition TEXT NOT NULL,
    included_accessories TEXT NOT NULL DEFAULT 'None',
    remarks TEXT,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE service_orders (
    service_order_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    service_code VARCHAR(30) NOT NULL UNIQUE,
    device_id BIGINT NOT NULL REFERENCES devices(device_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    maintenance_type_id SMALLINT NOT NULL REFERENCES maintenance_types(maintenance_type_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    status_id SMALLINT NOT NULL REFERENCES service_statuses(status_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    created_by_account_id BIGINT NOT NULL REFERENCES system_accounts(account_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    service_name VARCHAR(150) NOT NULL,
    description TEXT,
    estimated_cost NUMERIC(12, 2) NOT NULL DEFAULT 0.00 CHECK (estimated_cost >= 0.00),
    requested_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    started_at TIMESTAMPTZ,
    completed_at TIMESTAMPTZ,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE maintenance_tasks (
    maintenance_task_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    service_order_id BIGINT NOT NULL REFERENCES service_orders(service_order_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    technician_id BIGINT NOT NULL REFERENCES technicians(technician_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    maintenance_type_id SMALLINT NOT NULL REFERENCES maintenance_types(maintenance_type_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    started_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    ended_at TIMESTAMPTZ,
    labor_cost NUMERIC(12, 2) NOT NULL DEFAULT 0.00 CHECK (labor_cost >= 0.00),
    observations TEXT,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE preventive_maintenances (
    preventive_maintenance_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    maintenance_task_id BIGINT NOT NULL UNIQUE REFERENCES maintenance_tasks(maintenance_task_id) ON UPDATE CASCADE ON DELETE CASCADE,
    checklist_protocol TEXT NOT NULL,
    consumables_cost NUMERIC(12, 2) NOT NULL DEFAULT 0.00 CHECK (consumables_cost >= 0.00),
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE corrective_maintenances (
    corrective_maintenance_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    maintenance_task_id BIGINT NOT NULL UNIQUE REFERENCES maintenance_tasks(maintenance_task_id) ON UPDATE CASCADE ON DELETE CASCADE,
    diagnosed_fault TEXT NOT NULL,
    replaced_components TEXT NOT NULL DEFAULT 'None',
    replacement_parts_cost NUMERIC(12, 2) NOT NULL DEFAULT 0.00 CHECK (replacement_parts_cost >= 0.00),
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE device_deliveries (
    delivery_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    service_order_id BIGINT NOT NULL UNIQUE REFERENCES service_orders(service_order_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    delivered_by_account_id BIGINT NOT NULL REFERENCES system_accounts(account_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    delivery_date TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    customer_accepted BOOLEAN NOT NULL DEFAULT TRUE,
    remarks TEXT,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    updated_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE system_activities (
    activity_id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    activity_name VARCHAR(100) NOT NULL,
    reference_code VARCHAR(50) NOT NULL,
    account_id BIGINT NOT NULL REFERENCES system_accounts(account_id) ON UPDATE CASCADE ON DELETE RESTRICT,
    activity_date TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP,
    status_snapshot VARCHAR(50) NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    created_at TIMESTAMPTZ NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_customers_individual_id ON customers(individual_id);
CREATE INDEX idx_technicians_individual_id ON technicians(individual_id);
CREATE INDEX idx_account_roles_account_id ON account_roles(account_id);
CREATE INDEX idx_account_roles_individual_id ON account_roles(individual_id);
CREATE INDEX idx_account_roles_role_id ON account_roles(role_id);
CREATE INDEX idx_devices_customer_id ON devices(customer_id);
CREATE INDEX idx_devices_device_type_id ON devices(device_type_id);
CREATE INDEX idx_device_receipts_device_id ON device_receipts(device_id);
CREATE INDEX idx_device_receipts_account_id ON device_receipts(received_by_account_id);
CREATE INDEX idx_service_orders_device_id ON service_orders(device_id);
CREATE INDEX idx_service_orders_status_id ON service_orders(status_id);
CREATE INDEX idx_service_orders_maintenance_type_id ON service_orders(maintenance_type_id);
CREATE INDEX idx_service_orders_created_by ON service_orders(created_by_account_id);
CREATE INDEX idx_maintenance_tasks_service_order_id ON maintenance_tasks(service_order_id);
CREATE INDEX idx_maintenance_tasks_technician_id ON maintenance_tasks(technician_id);
CREATE INDEX idx_maintenance_tasks_type_id ON maintenance_tasks(maintenance_type_id);
CREATE INDEX idx_preventive_maintenances_task_id ON preventive_maintenances(maintenance_task_id);
CREATE INDEX idx_corrective_maintenances_task_id ON corrective_maintenances(maintenance_task_id);
CREATE INDEX idx_device_deliveries_account_id ON device_deliveries(delivered_by_account_id);
CREATE INDEX idx_system_activities_account_id ON system_activities(account_id);
CREATE INDEX idx_system_activities_activity_date ON system_activities(activity_date DESC);

INSERT INTO roles (role_name, description) VALUES
    ('Administrator', 'Supervisión general, reportes y parametrización de catálogos'),
    ('Receptionist', 'Atención inicial, recepción y entrega de equipos'),
    ('Technician', 'Diagnóstico y ejecución de mantenimientos en taller');

INSERT INTO service_statuses (status_name, description) VALUES
    ('Pending', 'Servicio registrado, en espera de asignación/diagnóstico'),
    ('InDiagnosis', 'Equipo en evaluación y revisión inicial'),
    ('InProgress', 'Mantenimiento o reparación en ejecución'),
    ('Completed', 'Trabajo técnico finalizado, listo para entrega'),
    ('Delivered', 'Equipo entregado con conformidad al cliente'),
    ('Cancelled', 'Servicio suspendido o cancelado');

INSERT INTO maintenance_types (type_name, description) VALUES
    ('Preventive', 'Limpieza, lubricación, optimización y rutinas sistemáticas'),
    ('Corrective', 'Sustitución de componentes defectuosos y resolución de averías');

INSERT INTO device_types (type_name, description) VALUES
    ('Laptop', 'Computadoras portátiles'),
    ('PC', 'Computadoras de escritorio'),
    ('Server', 'Servidores y estaciones de trabajo'),
    ('Smartphone', 'Teléfonos celulares y tabletas'),
    ('UPS', 'Sistemas de alimentación ininterrumpida y bancos de baterías');

COMMIT;
