﻿using Fur.DatabaseAccessor.Contexts;
using Fur.DatabaseAccessor.MultipleTenants;
using Fur.DatabaseAccessor.MultipleTenants.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Fur.EntityFramework.Core.DbContexts
{
    /// <summary>
    /// 多租户数据库上下文
    /// </summary>
    public class FurMultipleTenantDbContext : FurDbContextOfT<FurMultipleTenantDbContext, FurMultipleTenanDbContextLocator>
    {
        #region 构造函数 + public FurMultiTenantDbContext(DbContextOptions<FurMultiTenantDbContext> options)
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options">数据库上下文选项配置，<see cref="DbContextOptions{TContext}"/></param>
        public FurMultipleTenantDbContext(DbContextOptions<FurMultipleTenantDbContext> options)
            : base(options)
        {
        }
        #endregion

        #region 数据库上下文初始化调用方法 + protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        /// <summary>
        /// 数据库上下文初始化调用方法
        /// <para>通常配置数据库连接字符串，数据库类型等等</para>
        /// </summary>
        /// <param name="optionsBuilder">数据库上下文选项配置构建器，参见：<see cref="DbContextOptionsBuilder"/></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        #endregion

        #region 数据库上下文创建模型调用方法 + protected override void OnModelCreating(ModelBuilder modelBuilder)
        /// <summary>
        /// 数据库上下文创建模型调用方法
        /// </summary>
        /// <param name="modelBuilder">模型构建器，参见：<see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        public virtual Guid GetTenantId(string host)
        {
            var tenant = this.Set<Tenant>().FirstOrDefault(t => t.Host == host);
            return tenant?.TenantId ?? Guid.Empty;
        }

        public virtual string GetSchema(string host)
        {
            var tenant = this.Set<Tenant>().FirstOrDefault(t => t.Host == host);
            return tenant?.Schema;
        }

        public virtual string GetConnectionString(string host)
        {
            var tenant = this.Set<Tenant>().FirstOrDefault(t => t.Host == host);
            return tenant?.ConnectionString;
        }
    }
}