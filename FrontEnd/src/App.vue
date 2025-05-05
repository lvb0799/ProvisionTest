<template>
  <div class="container">
    <h1>上市公司營收資料查詢</h1>
    <RevenueTable />
  </div>
</template>

<script setup>
import RevenueTable from './components/RevenueTable.vue'
</script>

<style>
.container {
  max-width: 1200px;
  margin: 0 auto;
  padding: 24px;
  background-color: white;
  border-radius: 16px;
  box-shadow: 0 8px 24px rgba(0, 0, 0, 0.1); /* 浮出卡片感 */
}
h1 {
  background: linear-gradient(to right, #4facfe, #00f2fe); /* 背景漸層 */
  color: white;                      /* 白色文字 */
  padding: 20px 30px;               /* 內距增加立體感 */
  border-radius: 12px;              /* 圓角 */
  text-align: center;               /* 置中 */
  box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2); /* 陰影 */
  font-size: 28px;                  /* 字體大小 */
  font-weight: bold;                /* 粗體 */
  letter-spacing: 1px;              /* 字距微調 */
  margin-bottom: 24px;              /* 下方間距 */
}
</style>
