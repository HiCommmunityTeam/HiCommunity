/*
Navicat MySQL Data Transfer

Source Server         : mysql
Source Server Version : 50713
Source Host           : localhost:3306
Source Database       : hicommunitydb

Target Server Type    : MYSQL
Target Server Version : 50713
File Encoding         : 65001

Date: 2016-07-14 09:40:08
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for hc_backgrounduser
-- ----------------------------
DROP TABLE IF EXISTS `hc_backgrounduser`;
CREATE TABLE `hc_backgrounduser` (
  `Id` varchar(16) NOT NULL,
  `UserID` varchar(16) DEFAULT NULL,
  `PurviewStr` varchar(32) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hc_backgrounduser
-- ----------------------------

-- ----------------------------
-- Table structure for hc_categorybaseinfo
-- ----------------------------
DROP TABLE IF EXISTS `hc_categorybaseinfo`;
CREATE TABLE `hc_categorybaseinfo` (
  `Id` varchar(16) NOT NULL,
  `CategoryName` varchar(32) DEFAULT NULL COMMENT '模块名称',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hc_categorybaseinfo
-- ----------------------------

-- ----------------------------
-- Table structure for hc_notifymsgbaseinfo
-- ----------------------------
DROP TABLE IF EXISTS `hc_notifymsgbaseinfo`;
CREATE TABLE `hc_notifymsgbaseinfo` (
  `Id` varchar(16) NOT NULL,
  `UserID` varchar(16) DEFAULT NULL COMMENT '用户ID',
  `MsgType` varchar(16) DEFAULT NULL COMMENT '消息类型',
  `MsgConect` varchar(5000) DEFAULT NULL COMMENT '消息内容',
  `MsgStatus` int(10) DEFAULT '0' COMMENT '发送状态',
  `TimeMark` datetime DEFAULT NULL COMMENT '发送时间',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hc_notifymsgbaseinfo
-- ----------------------------

-- ----------------------------
-- Table structure for hc_tableid
-- ----------------------------
DROP TABLE IF EXISTS `hc_tableid`;
CREATE TABLE `hc_tableid` (
  `TableName` varchar(16) NOT NULL COMMENT '表名',
  `ColumnName` varchar(16) NOT NULL COMMENT '列名',
  `CurrentID` int(11) DEFAULT NULL COMMENT '列的长度',
  PRIMARY KEY (`TableName`,`ColumnName`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hc_tableid
-- ----------------------------

-- ----------------------------
-- Table structure for hc_threadbaseinfo
-- ----------------------------
DROP TABLE IF EXISTS `hc_threadbaseinfo`;
CREATE TABLE `hc_threadbaseinfo` (
  `Id` varchar(16) NOT NULL COMMENT 'Id',
  `ThreadTitle` varchar(200) DEFAULT NULL COMMENT '帖子标题',
  `ThreadContent` varchar(8096) DEFAULT NULL COMMENT '帖子内容',
  `ThreadAudio` varchar(500) DEFAULT NULL COMMENT '帖子音频',
  `ThreadImage` varchar(500) DEFAULT NULL COMMENT '帖子图片',
  `TimeMark` datetime DEFAULT NULL COMMENT '创建时间',
  `TagID` varchar(16) DEFAULT NULL COMMENT '标签ID',
  `CategoryID` varchar(16) DEFAULT NULL COMMENT '类型(模块)ID',
  `UserID` varchar(16) DEFAULT NULL COMMENT '发帖人ID',
  `PraiseUsers` varchar(5000) DEFAULT NULL COMMENT '点赞的人',
  `PraiseCount` int(8) unsigned zerofill DEFAULT '00000000' COMMENT '点赞数',
  `ReplyCount` int(8) DEFAULT '0' COMMENT '评论数',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hc_threadbaseinfo
-- ----------------------------

-- ----------------------------
-- Table structure for hc_threadreplybaseinfo
-- ----------------------------
DROP TABLE IF EXISTS `hc_threadreplybaseinfo`;
CREATE TABLE `hc_threadreplybaseinfo` (
  `Id` varchar(16) NOT NULL,
  `ReplyUID` varchar(16) DEFAULT NULL COMMENT '回帖人ID',
  `TimeMark` datetime DEFAULT NULL COMMENT '回帖时间',
  `ReplyText` varchar(8096) DEFAULT NULL COMMENT '回帖内容',
  `ReplyAudio` varchar(500) DEFAULT NULL COMMENT '回帖音频',
  `ReplyImage` varchar(500) DEFAULT NULL COMMENT '回帖图片',
  `ReplyToUID` varchar(16) DEFAULT NULL COMMENT '发帖人ID',
  `ThreadID` varchar(16) DEFAULT NULL COMMENT '帖子ID',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hc_threadreplybaseinfo
-- ----------------------------

-- ----------------------------
-- Table structure for hc_threadtagbaseinfo
-- ----------------------------
DROP TABLE IF EXISTS `hc_threadtagbaseinfo`;
CREATE TABLE `hc_threadtagbaseinfo` (
  `Id` varchar(16) NOT NULL,
  `TypeName` varchar(32) DEFAULT NULL COMMENT '标签类型',
  `TagName` varchar(64) DEFAULT NULL COMMENT '标签名称',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hc_threadtagbaseinfo
-- ----------------------------

-- ----------------------------
-- Table structure for hc_userbaseinfo
-- ----------------------------
DROP TABLE IF EXISTS `hc_userbaseinfo`;
CREATE TABLE `hc_userbaseinfo` (
  `Id` varchar(16) NOT NULL COMMENT 'Id',
  `EMail` varchar(64) DEFAULT NULL COMMENT '邮箱',
  `UserName` varchar(64) NOT NULL COMMENT '用户姓名',
  `UserPassWord` varchar(64) DEFAULT NULL COMMENT '用户密码',
  `Sex` varchar(10) DEFAULT NULL COMMENT '性别',
  `CellPhone` varchar(32) DEFAULT NULL COMMENT '手机号',
  `RegisterDate` datetime DEFAULT NULL COMMENT '注册时间',
  `RegisterType` varchar(16) DEFAULT NULL COMMENT '注册类型（web，WeiXin）',
  `LastLoginDate` datetime DEFAULT NULL COMMENT '最后一次登录时间',
  `LoginType` varchar(16) DEFAULT NULL COMMENT '登录方式（web, WeiXin）',
  `LoginOpenID` varchar(32) DEFAULT NULL COMMENT '登陆ID',
  `WXUnionID` varchar(16) DEFAULT NULL COMMENT '微信UnionID',
  `WxOpenID` varchar(32) DEFAULT NULL COMMENT '微信OpenID',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of hc_userbaseinfo
-- ----------------------------
