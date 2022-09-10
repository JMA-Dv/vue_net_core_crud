<template>
  <div class="columns is-centered">
    <div class="column is-7">

      <div class="box">
        <div class="tabs is-boxed">
          <ul>
            <li :class="{ 'is-active': tab === 'login' }">
              <a @click="tab = 'login'">Login</a>
            </li>
            <li :class="{ 'is-active': tab === 'register' }">
              <a @click="tab = 'register'">Registro</a>
            </li>
          </ul>
        </div>
        <Transition name="slide-fade">
          <form @submit.prevent="processForm" v-if="tab === 'login'">
            <div class="field">
              <label class="label">Email</label>
              <div class="control">
                <input v-model.trim="user.email" class="input" :class="{ 'is-danger': errorMessage.type === 'EMAIL' }"
                  type="email" placeholder="Email@example.com">
              </div>
              <p v-if="errorMessage.type === 'EMAIL'" class="help is-danger">This email is invalid</p>
            </div>
            <div class="field">
              <label class="label">Password</label>
              <div class="control">
                <input class="input" v-model="user.password" type="password" placeholder="example">
              </div>
            </div>
            <div class="field  is-grouped-centered">
              <div class="control">
                <button class="button is-link" @click="logIn">Log In</button>
              </div>
            </div>
          </form>
        </Transition>
        <Transition name="slide-fade">
          <form @submit.prevent="processForm" v-if="tab === 'register'">
            <div class="field">
              <label class="label">First Name</label>
              <div class="control ">
                <input class="input" type="text" placeholder="example example" v-model="user.firstName">
              </div>
            </div>

            <div class="field">
              <label class="label">Last Name</label>
              <div class="control ">
                <input class="input" type="text" placeholder="example example" v-model="user.lastName">
              </div>
            </div>

            <div class="field">
              <label class="label">Email</label>
              <div class="control">
                <input v-model.trim="user.email" class="input" :class="{ 'is-danger': errorMessage.type === 'EMAIL' }"
                  type="email" placeholder="Email@example.com">
              </div>
              <p v-if="errorMessage.type === 'EMAIL'" class="help is-danger">This email is invalid</p>
            </div>

            <div class="field">
              <label class="label">Password</label>
              <div class="control">
                <input v-model.trim="user.password" class="input"
                  :class="{ 'is-danger': errorMessage.type === 'PASSWORD' }" type="password" placeholder="********">
              </div>
              <p v-if="errorMessage.type === 'PASSWORD'" class="help is-danger">Password </p>
            </div>

            <div class="field  is-grouped-centered">
              <div class="control">
                <button class="button is-link" :disabled="loading" @click="signUp">Sign Up</button>
              </div>
            </div>
          </form>
        </Transition>

      </div>
    </div>

  </div>
</template>

<script>
import { ref } from 'vue'
import { useRouter } from 'vue-router';
import { useApi } from '../services/useApi';

export default {
  
  setup() {
    const errorMessage = ref({ type: '', error: '' });
    const tab = ref('login');
    const CREDENTIALS_ERROR = "The credentials are not correct"
    const api = useApi();
    const isLoading = ref(false);
    const useRoute = useRouter()

    const user = ref({
      email: '',
      firstName: '',
      lastName: '',
      password: ''
    })

    const processForm = () => {
      if (!user.value.email.trim()) {
        errorMessage.value.type = "EMAIL";
        errorMessage.value.error = CREDENTIALS_ERROR;
        return;
      }

      if (!user.value.password || user.value.password.length < 6) {
        errorMessage.value.type = "PASSWORD";
        errorMessage.value.error = CREDENTIALS_ERROR;
      }

      if (tab.value === 'register') {
        if (!user.value.firstName.trim()) {
          errorMessage.value = "FIRST_EMAIL";
          return;
        }

        if (!user.value.lastName.trim()) {
          errorMessage.value = "LAST_EMAIL";
          return;
        }
      }
    }

    const signUp = async () => {
      isLoading.value = true;
      await api.signUp(user.value);
      isLoading.value = false;
    }

    const logIn = async () => {
      isLoading.value = true;
      var response = await api.logIn(user.value);
      isLoading.value = false;

      if (response) {
        console.log("Entro")
        await useRoute.push('/')
      }
    }

    return { processForm, user, errorMessage, tab, signUp, logIn, isLoading }
  }
}
</script>
<style>
.slide-fade-enter-active {
  transition: all 0.3s ease-out;
  transition-delay: 0.4s;

}

.slide-fade-leave-active {
  transition: all 0.1s cubic-bezier(1, 0.5, 0.8, 1);

}

.slide-fade-enter-from,
.slide-fade-leave-to {
  transform: translateX(20px);
  opacity: 0;
}
</style>