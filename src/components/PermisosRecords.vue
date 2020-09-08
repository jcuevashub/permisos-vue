<template>
  <div class="container-fluid">
    <div class="hello">
      <h1>{{ title }}</h1>
    </div>
    <b-alert :show="loading" variant="info">Loading...</b-alert>
    <b-row>
      <b-col>
        <table class="table">
          <thead>
            <tr>
              <th>ID</th>
              <th>Nombre Empleado</th>
              <th>Apellidos Empleado</th>
              <th>Tipo Permiso</th>
              <th>Fecha Permiso</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="record in records" :key="record.id">
              <td>{{ record.id }}</td>
              <td>{{ record.employeeName }}</td>
              <td>{{ record.employeeLastName }}</td>
              <td>{{ record.tipoPermiso.description }}</td>
              <td>{{ record.fechaPermiso }}</td>
              <td class="text-center">
                <button
                  type="button"
                  class="btn btn-outline-primary"
                  @click.prevent="updatePermisoRecord(record)"
                >
                  Edit
                </button>
                <button
                  type="button"
                  class="btn btn-outline-danger"
                  @click.prevent="deletePermisoRecord(record.id)"
                >
                  Delete
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </b-col>
      <b-col lg="2">
        <b-card
          :title="model.id ? 'Editar permiso:' + model.id : 'Nuevo permiso'"
        >
          <form @submit.prevent="createPermisoRecord">
            <b-form-group label="Nombre">
              <b-form-input
                type="text"
                v-model="model.employeeName"
              ></b-form-input>
            </b-form-group>
            <b-form-group label="Apellido">
              <b-form-input
                type="text"
                v-model="model.employeeLastName"
              ></b-form-input>
            </b-form-group>
            <b-form-group label="Tipo de Permiso">
              <select v-model="model.TipoPermisoId" class="form-control">
                <option disabled value="" selected="selected"
                  >Please select one</option
                >
                <option
                  v-for="permiso in permisos"
                  :key="permiso.id"
                  v-bind:value="permiso.id"
                >
                  {{ permiso.description }}
                </option>
              </select>
            </b-form-group>
            <b-form-group label="Date Time">
              <b-form-input
                rows="4"
                v-model="model.fechaPermiso"
                type="datetime-local"
              ></b-form-input>
            </b-form-group>
            <div>
              <b-btn type="submit" variant="success">Save Record</b-btn>
            </div>
          </form>
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import api from "@/PermisosApiService";

export default {
  data() {
    return {
      loading: false,
      title: "Lista de Permisos",
      records: [],
      model: {},
      permisos: [],
      permiso: ""
    };
  },
  async created() {
    this.getAll();
    this.getAllPermisos();
  },

  methods: {
    async getAllPermisos() {
      this.permisos = await api.getAllPermisos();
    },
    async getAll() {
      this.loading = true;

      try {
        this.records = await api.getAll();
        console.log(this.records);
      } finally {
        this.loading = false;
      }
    },

    async updatePermisoRecord(permisoRecord) {
      this.model = Object.assign({}, permisoRecord);
    },

    async createPermisoRecord() {
      const isUpdate = !!this.model.id;
      if (isUpdate) {
        await api.update(this.model.id, this.model);
      } else {
        await api.create(this.model);
      }

      this.model = {};

      await this.getAll();
    },

    async deletePermisoRecord(id) {
      if (confirm("Are you sure you want to delete this record?")) {
        if (this.model.id === id) {
          this.model = {};
        }

        await api.delete(id);
        await this.getAll();
      }
    }
  }
};
</script>
<style>
h1 {
  margin: 10px;
}
</style>
