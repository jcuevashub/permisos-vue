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
          <form @submit.prevent="submit">
            <b-form-group label="First Name">
              <div
                class="form-group"
                :class="{ 'form-group--error': $v.employeeName.$error }"
              >
                <input
                  v-model="model.employeeName"
                  class="form-control"
                  v-model.trim="$v.employeeName.$model"
                />
              </div>
              <div class="error" v-if="!$v.employeeName.minLength">
                First Name must have at least
                {{ $v.employeeName.$params.minLength.min }} letters.
              </div>
            </b-form-group>

            <b-form-group label="Last Name">
              <div
                class="form-group"
                :class="{ 'orm-control--error': $v.employeeLastName.$error }"
              >
                <input
                  v-model="model.employeeLastName"
                  class="form-control"
                  v-model.trim="$v.employeeLastName.$model"
                />
              </div>

              <div class="error" v-if="!$v.employeeLastName.minLength">
                Last Name must have at least
                {{ $v.employeeLastName.$params.minLength.min }} letters.
              </div>
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
              <b-btn
                class="button"
                type="submit"
                variant="success"
                :disabled="submitStatus === 'PENDING'"
              >
                Save Record
              </b-btn>
            </div>
            <p class="typo__p" v-if="submitStatus === 'OK'">
              Thanks for your submission!
            </p>
            <p class="typo__p" v-if="submitStatus === 'ERROR'">
              Please fill the form correctly.
            </p>
            <p class="typo__p" v-if="submitStatus === 'PENDING'">Sending...</p>
          </form>
        </b-card>
      </b-col>
    </b-row>
  </div>
</template>

<script>
import api from "@/PermisosApiService";
import { required, minLength } from "vuelidate/lib/validators";

export default {
  data() {
    return {
      employeeName: "",
      employeeLastName: "",
      submitStatus: null,
      loading: false,
      title: "Lista de Permisos",
      records: [],
      model: {},
      permisos: [],
      permiso: ""
    };
  },
  validations: {
    employeeName: {
      required,
      minLength: minLength(3)
    },
    employeeLastName: {
      required,
      minLength: minLength(3)
    }
  },
  async created() {
    this.getAll();
    this.getAllPermisos();
  },

  methods: {
    submit() {
      console.log("submit!");
      this.$v.$touch();
      if (this.$v.$invalid) {
        this.submitStatus = "ERROR";
      } else {
        this.createPermisoRecord();
        this.submitStatus = "PENDING";
        setTimeout(() => {
          this.submitStatus = "OK";
        }, 500);
      }
    },
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
