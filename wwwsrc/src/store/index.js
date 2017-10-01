import axios from 'axios'
import vue from 'vue'
import vuex from 'vuex'

let api = axios.create({
  baseURL: 'http://localhost:5000/api/',
  timeout: 10000,
  withCredentials: true
})

vue.use(vuex)

var store = new vuex.Store({
  state: {
    user: {},
    keeps: []
  },
  mutations: {
    setKeeps(state, data) {
      state.keeps = data
    },
    createUser(state, user) {
      state.user = user
    },
    login(state, user) {
      state.user = user
      console.log(user);
    },
    logout(state, user) {
      state.user = {}
    }
  },
  actions: {
    getKeeps({ commit, dispatch }) {
      api('keeps').then(res => {
        console.log("Keeps:", res.data)
        commit('setKeeps', res.data)
      }).catch(err => {
        console.error(err)
      })
    },

    //User sign up, logout, and login functions
    createUser({ commit, dispatch }, user) {
      api.post('account', user)
        .then(res => {
          commit('createUser', res.data)
        })
    },
    login({ commit, dispatch }, user) {
      api.post('account/login', user)
        .then(res => {
          commit('login', res.data)
        })
    },
    logout({ commit, dispatch }) {
      api.delete('account/logout')
        .then(commit('logout'))
    },

    auth({ commit, dispatch }) {
      api('account').then(res => {
        console.log("Auth Response", res.data)
        commit('login', res.data)
      })
    }
  }
})


export default store

